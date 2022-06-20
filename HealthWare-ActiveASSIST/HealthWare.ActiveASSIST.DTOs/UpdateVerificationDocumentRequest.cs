namespace HealthWare.ActiveASSIST.DTOs
{
    public class UpdateVerificationDocumentRequest
    {
        public long AssessmentId { get; set; }
        public string DocumentTypeName { get; set; }
        public string Category { get; set; }
    }
}