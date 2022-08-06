using System;
using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class AdvocateDashboardResponse
    {
        public string CreateDate { get; set; }
        public DateTime AssessmentCreatedDate { get; set; }
        public List<DashboardAssessment> DashboardAssessments { get; set; }
    }

    public class DashboardAssessment
    {
        public long AssessmentId { get; set; }
        public long AssessmentPatientId { get; set; }
        public long CreatedBy { get; set; }
        public string AssessmentStatus { get; set; }
        public string PatientProfileImage { get; set; }
        public string PatientName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string SubmittedOn { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Programs { get; set; }
        public bool IsEditable { get; set; }
    }
}
