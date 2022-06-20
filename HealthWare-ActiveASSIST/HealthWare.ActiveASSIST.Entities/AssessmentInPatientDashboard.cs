using System;

namespace HealthWare.ActiveASSIST.Entities
{
    public class AssessmentInPatientDashboard
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public long AssessmentId { get; set; }
        public string AssessmentStatus { get; set; }
        public string Programs { get; set; }
        public long PatientId { get; set; }
        public string ProfileImageData { get; set; }
        public string SubmittedByName { get; set; }
        public string SubmittedOn { get; set; }
        public DateTime CreatedDate { get; set; }
        //Todo: What is the mapping? City of the hospital needed?
        public string HospitalName { get; set; }
        public string CellNumber { get; set; }
        public string CountryCode { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool IsEditable { get; set; }
        public string StatusDisplayName { get; set; }
        public string CountyCode { get; set; }
        public string Cell { get; set; }

    }
}
