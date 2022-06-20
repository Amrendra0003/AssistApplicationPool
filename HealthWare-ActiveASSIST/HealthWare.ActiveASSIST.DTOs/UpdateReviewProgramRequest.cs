namespace HealthWare.ActiveASSIST.DTOs
{
    public class UpdateReviewProgramRequest: BasePatientAssessment
    {
        public long ProgramId { get; set; }
        public bool IsActive { get; set; }
        public bool IsEvaluated { get; set; }
    }
}
