using Healthware.Core.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using Healthware.Core.Entities;
using Healthware.Core.Extensions;
using Healthware.Core.Security;
using Microsoft.EntityFrameworkCore;

namespace Healthware.Core.Repository
{
    public interface IUserRepository<TK> : IUserStore<MainUser>, IUserPasswordStore<MainUser> where TK : DbContext
    {
        Task<long> CreateUser(MainUser user);
        Task<MainUser> GetUserByEmailAddress(string emailAddress);
        Task<bool> IsUserExists(string emailAddress);
        Task<bool> UpdateUserByOtp(MainUser user, string otp);
        Task<bool> IsUserActive(string emailAddress);
        Task<bool> UpdateUserPassword(MainUser user, string confirmPassword);
        Task<bool> UpdateCanChangePassword(MainUser user, bool value);
        Task<bool> UpdateIsUsernamePasswordValidated(MainUser user, bool value);
        Task<bool> UpdateOtpNumberAndIsUsernamePasswordValidated(MainUser user, bool value);
        Task<MainUser> GetUserById(long userId);
        //Task<bool> UpdateAssessmentVerificationByToken(Entities.AssessmentVerification verification, string token);
        Task<bool> Update(MainUser updatedUserProfile);
        Task<bool> ChangePassword(MainUser user, string newPassword);
    }

    public class UserRepository<TK> : IUserRepository<TK> where TK : DbContext
    {
        private readonly IUnitOfWork<TK> _unitOfWork;
        private readonly TK _context;

        public UserRepository(IUnitOfWork<TK> unitOfWork, TK context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<long> CreateUser(MainUser user)
        {
            _unitOfWork.Attach(user.ContactDetails?.ContactTypeDetails);
            await _unitOfWork.AddAsync(user);
            await _unitOfWork.CommitAsync();
            return user.Id;
        }

        public async Task<MainUser> GetUserByEmailAddress(string emailAddress)
        {
            var user = await _unitOfWork.GetEntityAsync<MainUser>(x => x.EmailAddress == emailAddress);
            return user;
        }

        public async Task<bool> IsUserExists(string emailAddress)
        {
            var user = await GetUserByEmailAddress(emailAddress);
            if (user.IsNotNull()) return true;
            return false;
        }

        public async Task<bool> UpdateUserByOtp(MainUser user, string otp)
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

        public async Task<bool> UpdateUserPassword(MainUser user, string confirmPassword)
        {
            if (user.ContactDetails.IsNotNull())
                _unitOfWork.Attach(user.ContactDetails);
            user.IsTokenConsumed = true;
            user.CanChangePassword = false;
            user.Password = PasswordEncryptionDecryption.HashPassword(confirmPassword);
            _unitOfWork.Update(user);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdateCanChangePassword(MainUser user, bool value)
        {
            if (user.ContactDetails.IsNotNull())
                _unitOfWork.Attach(user.ContactDetails);
            user.CanChangePassword = value;
            _unitOfWork.Update(user);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdateIsUsernamePasswordValidated(MainUser user, bool value)
        {
            if (user.ContactDetails.IsNotNull())
                _unitOfWork.Attach(user.ContactDetails);
            user.IsAuthenticated = value;
            _unitOfWork.Update(user);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdateOtpNumberAndIsUsernamePasswordValidated(MainUser user, bool value)
        {
            if (user.ContactDetails.IsNotNull())
                _unitOfWork.Attach(user.ContactDetails);
            user.OtpNumber = null;
            user.IsAuthenticated = value;
            _unitOfWork.Update(user);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<MainUser> GetUserById(long userId)
        {
            var user = await _unitOfWork.GetEntityAsync<MainUser>(x => x.Id == userId);
            return user;
        }

        public async Task<bool> Update(MainUser updatedUserProfile)
        {
            if (updatedUserProfile.ContactDetails.IsNotNull())
                _unitOfWork.Attach(updatedUserProfile.ContactDetails);
            _unitOfWork.Update(updatedUserProfile);
            var isUserUpdated = await _unitOfWork.CommitAsync();
            return isUserUpdated;
        }

        public async Task<bool> ChangePassword(MainUser user, string newPassword)
        {
            if (user.ContactDetails.IsNotNull())
                _unitOfWork.Attach(user.ContactDetails);
            user.Password = PasswordEncryptionDecryption.HashPassword(newPassword);
            _unitOfWork.Update(user);
            return await _unitOfWork.CommitAsync();
        }

        public void Dispose()
        {
        }

        public Task<string> GetUserIdAsync(MainUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(MainUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.EmailAddress);
        }

        public Task SetUserNameAsync(MainUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(MainUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(MainUser user, string normalizedName,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(MainUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(MainUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(MainUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<MainUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<MainUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(MainUser user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(MainUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(MainUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
