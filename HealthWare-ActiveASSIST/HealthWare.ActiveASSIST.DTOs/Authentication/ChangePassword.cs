using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs.Authentication
{
    public class ChangePassword: BaseUserAccountDetails
    {
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
