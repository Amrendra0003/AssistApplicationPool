namespace HealthWare.ActiveASSIST.DTOs
{
    public class GetGuarantorResponse
    {
        public long Id { get; set; }
        public long AssessmentId { get; set; }
        public string RelationShipWithPatient { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string EmailAddress { get; set; }
        public string Cell { get; set; }
        public string CountyCode { get; set; }
        public string SSNNumber { get; set; }
        public string ReasonNoSsn { get; set; }
        public string DateOfBirth { get; set; }
    }
}
