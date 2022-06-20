using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class IncomeDocument
    {
        public long AssessmentId { get; set; }
        public List<HouseHoldMemberDocument> HouseHoldMemberDocument { get; set; }
    }
    public class HouseHoldMemberDocument
    {
        public long HouseHoldMemberId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string RelationshipType { get; set; }
        public List<string> DocumentType { get; set; }
        public List<Documents> DocumentDetail { get; set; }
    }
    public class Documents
    {
        public long DocumentId { get; set; }
        public string DocumentName { get; set; }
    }
}
