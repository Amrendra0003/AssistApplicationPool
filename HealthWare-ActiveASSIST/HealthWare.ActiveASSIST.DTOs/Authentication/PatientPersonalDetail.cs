using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs.Authentication
{
    public class PatientPersonalDetail
    {
        [Required]
        public long Id { get; set; }
        public long AssessmentId { get; set; }
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string MiddleName { get; set; }
        public string EmailAddress { get; set; }
        [StringLength(50, ErrorMessage = Constants.GuarantorRequestValueMessage)]
        public string Suffix { get; set; }
        public string MaidenName { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public string CountyCode { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = Constants.NotValidCellNumber)]
        public string Cell { get; set; }
        [Required]
        public bool IsGuarantor { get; set; }
        public string SSN { get; set; }
        public string ReasonNoSSN { get; set; }

    }
}
