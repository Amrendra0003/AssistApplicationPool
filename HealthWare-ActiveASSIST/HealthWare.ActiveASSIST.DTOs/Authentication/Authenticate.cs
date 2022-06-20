using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs.Authentication
{
    public class Authenticate : BaseUserAccountDetails
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public override string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        //[StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }
        
    }
}
