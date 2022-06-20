namespace HealthWare.ActiveASSIST.DTOs
{
    public class AssessmentVerificationResponse
    {
        public bool IsEmailConfirmed { get; set; }
        public bool IsCellConfirmed { get; set; }
        public string CountyCode { get; set; }
        public string CellNumber { get; set; }
    }
}
