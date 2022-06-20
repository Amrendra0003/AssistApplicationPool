using System;
using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class DashboardDetailResponse
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public long AssessmentId { get; set; }
        public string AssessmentStatus { get; set; }
        public SubmittedBy SubmittedBy { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public Programs Programs { get; set; }
        public long PatientId { get; set; }
        public string ProfileImageData { get; set; }
        public bool IsEditable { get; set; }
        public string StatusDisplayName { get; set; }
        public string CellNumber { get; set; }
        public string CountyCode { get; set; }
    }
    public class SubmittedBy
    {
        public string Name { get; set; }
        public string SubmittedOn { get; set; }
        public DateTime CreatedDate { get; set; }
        public string HospitalName { get; set; }
        public string City { get; set; }
    }
    public class ContactDetails
    {
        public string CellNumber { get; set; }
        public string CountryCode { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string HomeCountryCode { get; set; }
        public string HomeCellNumber { get; set; }
    }
    public class Programs
    {
        public List<string> ProgramName { get; set; }
    }

    public class PartialAssessment
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public SubmittedBy SubmittedBy { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public long PartialAssessmentId { get; set; }
    }

    public class DashboardResponse
    {
        public List<DashboardDetailResponse> DashboardDetailResponse { get; set; }
        public PartialAssessment PartialAssessment { get; set; }
        public bool CanCreateNewAssessment { get; set; }
    }
}
