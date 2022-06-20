using Healthware.Core.Constants;
using Healthware.Core.DTO;
using Healthware.Core.Entities;
using Healthware.Core.Extensions;
using Healthware.Core.MultiTenancy.Entities;
using Healthware.Core.Repository;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities.UserManagement;
using HealthWare.ActiveASSIST.Repositories;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using HealthWare.ActiveASSIST.Services.Mapper;
using System.Globalization;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IUserVerificationService
    {
        Task<Result<MessageDto>> UpdateUserVerification(UpdateUserDetails updateUserDetails);
        Task<Result<PersonalDetail>> GetUserProfileDetail(string email);
    }
    public class UserVerificationService : IUserVerificationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserHasRolesRepository _rolesRepository;
        private readonly IUserMapper _userMapper;
        private readonly IContactDetailsRepository<PatientDbContext> _contactDetailsRepository;
        public UserVerificationService(IUserRepository userRepository, IUserHasRolesRepository rolesRepository, IUserMapper userMapper, IContactDetailsRepository<PatientDbContext> contactDetailsRepository)
        {
            _userRepository = userRepository;
            _rolesRepository = rolesRepository;
            _userMapper = userMapper;
            _contactDetailsRepository = contactDetailsRepository;
        }
        public async Task<Result<MessageDto>> UpdateUserVerification(UpdateUserDetails updateUserDetails)
        {
            var isUserExistsWithInActive = await _userRepository.IsEmailExistsWithInActive(updateUserDetails.PrimaryEmail);
            if (!isUserExistsWithInActive) return new Result<MessageDto>().AddError(Error.InvalidRequest);

            var isEmailExistsWithActiveUser = await _userRepository.IsEmailExistsWithActive(updateUserDetails.EmailAddress);
            if(isEmailExistsWithActiveUser) return new Result<MessageDto>().AddError(Constants.EmailAlreadyExists);

            var isEmailExistsWithSecondaryContactDetail = await _userRepository.IsEmailExistsWithSecondaryEmail(updateUserDetails.EmailAddress);
            if(isEmailExistsWithSecondaryContactDetail) return new Result<MessageDto>().AddError(Constants.EmailAlreadyExists);

            var user = await _userRepository.GetUserByEmailAddress(updateUserDetails.PrimaryEmail);
            if (user.IsNull()) return new Result<MessageDto>().AddError(Error.InvalidRequest);

            var updatedUser = _userMapper.MapFromUser(user, updateUserDetails);
            _ = await _contactDetailsRepository.UpdateContactDetails(updatedUser.ContactDetails);
            _ = await _userRepository.Update(updatedUser);
            _ = await _rolesRepository.CreateUserRole(new UserHasRoles { User = new User { Id = updatedUser.Id }, Role = new Role { Id = Entities.Master.Roles.Patient.Id } });
            return new Result<MessageDto> { Data = new MessageDto().AddMessage(Constants.UserVerificationUpdatedSuccessfully) };
        }
        async Task<Result<PersonalDetail>> IUserVerificationService.GetUserProfileDetail(string email)
        {
            var user = await _userRepository.GetUserByEmailAddress(email);
            if(user.IsNull()) return new Result<PersonalDetail>().AddError(Error.UserNotFound);

            var personDetail = new PersonalDetail
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                DateOfBirth = user.DateOfBirth?.ToString(Constants.MonthDayYear, CultureInfo.InvariantCulture),
                Cell = user.Cell,
                CountyCode = user.CountyCode,
                Email = user.EmailAddress,
                UserId = user.Id.ToString()
            };

            return new Result<PersonalDetail> { Data = personDetail };
        }
    }
}
