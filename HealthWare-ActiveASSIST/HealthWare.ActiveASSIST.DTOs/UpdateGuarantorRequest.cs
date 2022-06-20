using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class UpdateGuarantorRequest: BasePatientAssessment
    {
        [Required]
        public long GuarantorId { get; set; }
        public string RelationshipWithPatient { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string DateOfBirth { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Cell { get; set; }
        public string CountyCode { get; set; }
        
        public string SSNNumber { get; set; }
        public string ReasonNoSsn { get; set; }
        public string BasicContactId { get; set; }
        public long BasicInfoId { get; set; }
    }
}
