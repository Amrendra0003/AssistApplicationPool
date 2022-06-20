using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class AssessmentEvaluationResponse
    {
        public long AssessmentId { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string FullName { get; set; }
        public string AssessmentStatus { get; set; }
        public long BasicInfoId { get; set; }
        public string SubmittedOn { get; set; }
        public List<string> ProgramNames { get; set; }
        public bool Override { get; set; }
        public List<string> ProgramsOpted { get; set; }
        public List<string> AllPrograms { get; set; }
    }
}
