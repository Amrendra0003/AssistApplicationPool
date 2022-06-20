using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs.Authentication
{
    public class ForgotPassword : BaseUserAccountDetails
    {
        [Required]
        [EmailAddress]
        public override string EmailAddress { get; set; }

    }
}
