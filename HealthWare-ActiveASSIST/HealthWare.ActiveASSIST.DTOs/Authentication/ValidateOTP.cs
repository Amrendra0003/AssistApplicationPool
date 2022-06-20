using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs.Authentication
{
    public class ValidateOTP: BasePatientAssessment
    {
        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = Constants.MaxFourCharactersRequired)]
        public string OtpNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
