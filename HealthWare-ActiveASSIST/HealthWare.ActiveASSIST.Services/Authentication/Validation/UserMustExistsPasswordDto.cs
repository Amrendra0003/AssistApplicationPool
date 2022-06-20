using System.Collections.Generic;
using HealthWare.ActiveASSIST.DTOs.Authentication;
using HealthWare.ActiveASSIST.Repositories;
using Healthware.Core.DTO;

namespace HealthWare.ActiveASSIST.Services.Authentication.Validation
{
    public class UserMustExistsPasswordDto: IValidator<ResetPassword>
    {
        private readonly IUserRepository _userRepository;
        public UserMustExistsPasswordDto(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ValidationResultDto Execute(ResetPassword resetPassword, IEnumerable<ResetPassword> resetPasswords)
        {
            return Execute(resetPassword);
        }

        public ValidationResultDto Execute(ResetPassword resetPassword)
        {
            var validationResult = new ValidationResultDto()
            {
                IsValid = false
            };

            validationResult.IsValid = _userRepository.IsUserExists(resetPassword.EmailAddress).GetAwaiter().GetResult();

            if (validationResult.IsValid) return validationResult;
            validationResult.Message = string.Format(Constants.UserNotExist,
                resetPassword.EmailAddress);
            return validationResult;
        }
    }
}
