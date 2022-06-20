using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class CellConfirmationOTPModel : BasePatientAssessment
    {
        [Required]
        public string CellNumber { get; set; }
    }
}
