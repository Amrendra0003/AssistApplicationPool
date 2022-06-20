namespace HealthWare.ActiveASSIST.DTOs
{
    public class BasePatientAssessment
    {
        public virtual long PatientId { get; set; }
        public virtual long AssessmentId { get; set; }
        public virtual long UserId { get; set; }
    }
}
