using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class HouseHoldMemberList
    {
        public List<MemberList> MemberLists { get; set; }
        public int TotalMembers { get; set; }
        public int Minors { get; set; }
        public string? TotalMonthlyIncome { get; set; }
        public string? TotalResource { get; set; }
        public string TotalHouseholdCount { get; set; }

        public class MemberList
        {
            public long HouseHoldMemberId { get; set; }
            public string Name { get; set; }
            public string Relation { get; set; }
            public string Age { get; set; }
            public string DateOfBirth { get; set; }
            public decimal? MonthlyIncome { get; set; }
            public string? MonthlyIncomeString { get; set; }
            public string IncomeCurrentStatus { get; set; }
            public string Source { get; set; }
            public decimal? Resource { get; set; }
            public string? ResourceString { get; set; }
            public string Type { get; set; }
            public bool CanDeleteHousehold { get; set; }
            public bool IsRequiredDetailsCompleted { get; set; } = true;
        }
    }
}
