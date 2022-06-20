using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs.Authentication
{
    public class SendOTP
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public bool LoginFlag { get; set; }
    }
}
