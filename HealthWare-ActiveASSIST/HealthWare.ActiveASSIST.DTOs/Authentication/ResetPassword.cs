using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs.Authentication
{
    public class ResetPassword : BaseUserAccountDetails
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(Constants.Password, ErrorMessage = Constants.PasswordConfirmationMismatch)]
        public string ConfirmPassword { get; set; }
    }
}
