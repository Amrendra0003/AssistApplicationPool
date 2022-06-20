using System.Collections.Generic;
using HealthWare.ActiveASSIST.DTOs.Authentication;
using HealthWare.ActiveASSIST.Repositories;
using Healthware.Core.DTO;

namespace HealthWare.ActiveASSIST.Services.Authentication.Validation
{
    public class UserMustExists : IValidator<ForgotPassword>
    {
        private readonly IUserRepository _userRepository;
        public UserMustExists(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ValidationResultDto Execute(ForgotPassword forgotPassword, IEnumerable<ForgotPassword> forgotPasswords)
        {
            return Execute(forgotPassword);
        }

        public ValidationResultDto Execute(ForgotPassword forgotPassword)
        {
            var validationResult = new ValidationResultDto()
            {
                IsValid = false
            };
            validationResult.IsValid = _userRepository.IsUserExists(forgotPassword.EmailAddress).GetAwaiter()
                .GetResult();

            if (!validationResult.IsValid)
            {
                validationResult.Message = string.Format(Constants.UserNotExist,
                    forgotPassword.EmailAddress);
            }
            else
            {
                validationResult.IsValid = true;
            }

            return validationResult;
        }
    }
}
