namespace HealthWare.ActiveASSIST.Entities
{
    public class HouseholdMemberDocument
    {
        public long Id { get; set; }
        public HouseHoldMember HouseholdMember { get; set; }
        public Document Document { get; set; }
    }
}
