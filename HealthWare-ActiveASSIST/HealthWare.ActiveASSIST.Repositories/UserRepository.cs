using Healthware.Core.Base;
using Healthware.Core.Extensions;
using Healthware.Core.MultiTenancy.Entities;
using Healthware.Core.Security;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Entities;
using Healthware.Core.Entities;
using ContactDetails = Healthware.Core.Entities.ContactDetails;


namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IUserRepository : IUserStore<User>, IUserPasswordStore<User>
    {
        Task<long> CreateUser(User user);
        Task<User> GetUserByEmailAddress(string emailAddress);
        Task<User> GetUserByEmailAddressAndTenantId(string emailAddress, string tenantId);
        Task<bool> IsUserExists(string emailAddress);
        Task<bool> IsUserExistsForPrimaryAndSecondaryEmail(string emailAddress);
        Task<bool> IsUserExistsByTenantId(string emailAddress, long tenantId);
        Task<bool> UpdateUserByOtp(User user, string otp);
        Task<bool> IsUserActive(string emailAddress);
        Task<bool> UpdateUserPassword(User user, string confirmPassword);
        Task<bool> UpdateCanChangePassword(User user, bool value);
        Task<bool> UpdateIsUsernamePasswordValidated(User user, bool value);
        Task<bool> UpdateOtpNumberAndIsUsernamePasswordValidated(User user, bool value);
        Task<User> GetUserById(long userId);
        IEnumerable<AssessmentResult> GetAssessmentList();
        Task<bool> Update(User updatedUserProfile);
        Task<bool> ChangePassword(User user, string newPassword);
        Task<IEnumerable<MainUser>> GetUserForAdvocateAssessment();
        Task<bool> IsEmailExistsWithInActive(string primaryEmail);
        Task<bool> IsEmailExistsWithSecondaryEmail(string emailAddress);
        Task<bool> IsEmailExistsWithActive(string emailAddress);
        Task<bool> IsPatientExists(string emailAddress);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        private readonly PatientDbContext _context;

        public UserRepository(IUnitOfWork<PatientDbContext> unitOfWork, PatientDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<long> CreateUser(User user)
        {
            _unitOfWork.Attach(user.ContactDetails.ContactTypeDetails);
            _unitOfWork.Attach(user.SecondaryEmailContactDetails.ContactTypeDetails);
            await _unitOfWork.AddAsync(user);
            await _unitOfWork.CommitAsync();
            return user.Id;
        }

        public async Task<User> GetUserByEmailAddress(string emailAddress)
        {
            var user = await _unitOfWork.GetEntityAsync<User>(x => x.EmailAddress == emailAddress);
            return user;
        }
        public async Task<User> GetUserByEmailAddressAndTenantId(string emailAddress, string tenantId)
        {
            var user = await _unitOfWork.GetEntityAsync<User>(x => x.EmailAddress == emailAddress && x.TenantId == tenantId);
            return user;
        }

        public async Task<bool> IsUserExists(string emailAddress)
        {
            var user = await GetUserByEmailAddress(emailAddress);
            if (user.IsNotNull()) return true;
            return false;
        }
        public async Task<bool> IsUserExistsForPrimaryAndSecondaryEmail(string emailAddress)
        {
            var user = await GetUserByEmailAddress(emailAddress);
            var secondaryEmailContactDetail = await _unitOfWork.GetEntityAsync<ContactDetails>(a => a.Email == emailAddress);
            if (user.IsNotNull() || secondaryEmailContactDetail.IsNotNull()) return true;
            return false;
        }
        public async Task<bool> IsUserExistsByTenantId(string emailAddress, long tenantId)
        {
            var user = await _unitOfWork.GetEntityAsync<User>(x => x.EmailAddress == emailAddress && x.TenantId == tenantId.ToString());
            if (user.IsNotNull()) return true;
            return false;
        }

        public async Task<bool> UpdateUserByOtp(User user, string otp)
        {
            if (user.ContactDetails.IsNotNull())
                _unitOfWork.Attach(user.ContactDetails);
            user.OtpNumber = otp;
            user.LoginOTPUpdatedTime = DateTime.UtcNow;
            _unitOfWork.Update(user);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsUserActive(string emailAddress)
        {
            var user = await GetUserByEmailAddress(emailAddress);
            return user is { IsActive: true };
        }

        public async Task<bool> UpdateUserPassword(User user, string confirmPassword)
        {
            if (user.ContactDetails.IsNotNull())
                _unitOfWork.Attach(user.ContactDetails);
            user.IsTokenConsumed = true;
            user.CanChangePassword = false;
            user.Password = PasswordEncryptionDecryption.HashPassword(confirmPassword);
            _unitOfWork.Update(user);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdateCanChangePassword(User user, bool value)
        {
            if (user.ContactDetails.IsNotNull())
                _unitOfWork.Attach(user.ContactDetails);
            user.CanChangePassword = value;
            _unitOfWork.Update(user);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdateIsUsernamePasswordValidated(User user, bool value)
        {
            if (user.ContactDetails.IsNotNull())
                _unitOfWork.Attach(user.ContactDetails);
            user.IsAuthenticated = value;
            _unitOfWork.Update(user);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdateOtpNumberAndIsUsernamePasswordValidated(User user, bool value)
        {
            if (user.ContactDetails.IsNotNull())
                _unitOfWork.Attach(user.ContactDetails);
            user.OtpNumber = null;
            user.IsAuthenticated = value;
            _unitOfWork.Update(user);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<User> GetUserById(long userId)
        {
            var user = await _unitOfWork.GetEntityAsync<User>(x => x.Id == userId);
            return user;
        }
        public IEnumerable<AssessmentResult> GetAssessmentList()
        {
            var assessmentList = from screenQuestionMapping in _context.ScreenQuestionMapping
                                 join question in _context.Question on screenQuestionMapping.QuestionId equals question.Id
                                 join screen in _context.Screen on screenQuestionMapping.ScreenId equals screen.Id
                                 join control in _context.Control on question.Control.Id equals control.Id
                                 join answerOption in _context.AnswerOption on question.Id equals answerOption.QuestionId into answerOptions
                                 from option in answerOptions.DefaultIfEmpty()
                                 //where question.RoleName == roleName || question.RoleName == null
                                 select new AssessmentResult()
                                 {
                                     ScreenId = (int)screenQuestionMapping.ScreenId,
                                     Name = screen.Name,
                                     Content = screen.Content,
                                     Description = screen.Description,
                                     ScreenQuestionMappingId = Convert.ToString(screenQuestionMapping.Id),
                                     QuestionId = (int)question.Id,
                                     QuestionName = question.QuestionName,
                                     DisplayFormat = question.DisplayFormat,
                                     ControlId = Convert.ToString(question.Control.Id),
                                     IsRequired = question.IsRequired,
                                     ParentId = (int)(question.ParentId ?? default),
                                     QuestionKeyName = screenQuestionMapping.KeyName,
                                     ControlType = control.ControlType,
                                     OptionId = option.IsNull() ? default : Convert.ToString(option.Id),
                                     KeyName = option.IsNull() ? default : option.Name,
                                     Value = option.IsNull() ? default : option.Value,
                                     Order = option.IsNull() ? default : option.Order
                                 };
            return assessmentList;
        }


        public async Task<bool> Update(User updatedUserProfile)
        {
            if (updatedUserProfile.ContactDetails.IsNotNull())
                _unitOfWork.Attach(updatedUserProfile.ContactDetails);
            _unitOfWork.Update(updatedUserProfile);
            var isUserUpdated = await _unitOfWork.CommitAsync();
            return isUserUpdated;
        }

        public async Task<bool> ChangePassword(User user, string newPassword)
        {
            if (user.ContactDetails.IsNotNull())
                _unitOfWork.Attach(user.ContactDetails);
            user.Password = PasswordEncryptionDecryption.HashPassword(newPassword);
            _unitOfWork.Update(user);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<MainUser>> GetUserForAdvocateAssessment()
        {
            var patients = from mainUser in _unitOfWork.GetEntities<MainUser>()
                                            join userHasRoles in _unitOfWork.GetEntities<UserHasRoles>() on mainUser.Id equals userHasRoles.User.Id
                                            join role in _unitOfWork.GetEntities<Role>() on userHasRoles.Role.Id equals role.Id
                                           where role.RoleName.Equals("Patient")
                                           select new MainUser()
                                           {
                                               Id = mainUser.Id,
                                               FirstName = mainUser.FirstName,
                                               LastName = mainUser.LastName,
                                               DateOfBirth = mainUser.DateOfBirth
                                           };
            return patients;
        }

        public async Task<bool> IsEmailExistsWithInActive(string primaryEmail)
        {
            var user = await _unitOfWork.GetEntityAsync<User>(a =>
                a.EmailAddress == primaryEmail && a.IsActive.Equals(false));
            if (user.IsNull()) return false;
            return true;
        }

        public async Task<bool> IsEmailExistsWithSecondaryEmail(string emailAddress)
        {
            var user = await _unitOfWork.GetEntityAsync<User>(a => a.SecondaryEmailContactDetails.Email == emailAddress && a.IsActive.Equals(true));
            if (user.IsNotNull()) return true;
            return false;
        }

        public async Task<bool> IsEmailExistsWithActive(string emailAddress)
        {
            var user = await _unitOfWork.GetEntityAsync<User>(a =>
                a.EmailAddress == emailAddress && a.IsActive.Equals(true));
            if (user.IsNotNull()) return true;
            return false;
        }

        public async Task<bool> IsPatientExists(string emailAddress)
        {
            var patient = await _unitOfWork.GetEntityAsync<Patient>(a => a.EmailAddress == emailAddress);
            if (patient.IsNotNull())
            {
                return true;
            }

            return false;
        }

        public void Dispose()
        {
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.EmailAddress);
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}