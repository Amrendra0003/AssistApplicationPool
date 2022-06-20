using System.Collections.Generic;
using HealthWare.ActiveASSIST.DTOs.Authentication;
using HealthWare.ActiveASSIST.Repositories;
using Healthware.Core.DTO;
using Healthware.Core.Extensions;
using Healthware.Core.Security;

namespace HealthWare.ActiveASSIST.Services.Authentication.Validation
{
    public class NewPasswordMustNotBeExistingPassword : IValidator<ResetPassword>, IValidator<ChangePassword>
    {
        private readonly IUserRepository _userRepository;
        public NewPasswordMustNotBeExistingPassword(IUserRepository userRepository)
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
            var userDetails = _userRepository.GetUserByEmailAddress(resetPassword.EmailAddress).GetAwaiter().GetResult();
            if (userDetails.IsNotNull() && userDetails.Password.IsNotNullOrEmpty())
            {
                validationResult.IsValid = !PasswordEncryptionDecryption.ValidatePassword(resetPassword.ConfirmPassword, userDetails.Password);
            }

            if (validationResult.IsValid) return validationResult;
            validationResult.Message = Constants.NewPasswordAlertMessage;
            return validationResult;
        }

        public ValidationResultDto Execute(ChangePassword changePassword, IEnumerable<ChangePassword> changePasswords)
        {
            return Execute(changePassword);
        }

        public ValidationResultDto Execute(ChangePassword changePassword)
        {
            var validationResult = new ValidationResultDto()
            {
                IsValid = false
            };
            var userDetails = _userRepository.GetUserByEmailAddress(changePassword.EmailAddress).GetAwaiter().GetResult();
            if (userDetails.IsNotNull() && userDetails.Password.IsNotNullOrEmpty())
            {
                validationResult.IsValid = !PasswordEncryptionDecryption.ValidatePassword(changePassword.NewPassword, userDetails.Password);
            }

            if (validationResult.IsValid) return validationResult;
            validationResult.Message = Constants.NewPasswordAlertMessage;
            return validationResult;
        }
    }
}
