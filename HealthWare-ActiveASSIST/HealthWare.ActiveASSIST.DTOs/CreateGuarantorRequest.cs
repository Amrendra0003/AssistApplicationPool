using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class CreateGuarantorRequest
    {
        [Required]
        public long AssessmentId { get; set; }
        [Required]
        public string RelationshipWithPatient { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [Required]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string MiddleName { get; set; }
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Suffix { get; set; }
        public string DateOfBirth { get; set; }
        [EmailAddress]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string EmailAddress { get; set; }
        public string Cell { get; set; }
        public string CountyCode { get; set; }
        [StringLength(15, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string SSNNumber { get; set; }
        public string ReasonNoSsn { get; set; }
    }
}