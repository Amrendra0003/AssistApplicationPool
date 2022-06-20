namespace HealthWare.ActiveASSIST.DTOs
{
    public class IncomeVerificationDocument
    {
        public long DocumentId { get; set; }
        public string DocumentName { get; set; }
        public long HouseHoldMemberId { get; set; }
        public string DocumentType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
    }
}
