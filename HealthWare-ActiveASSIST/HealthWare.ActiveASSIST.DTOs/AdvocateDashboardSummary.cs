namespace HealthWare.ActiveASSIST.DTOs
{
    public class AdvocateDashboardSummary
    {
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string CitizenshipStatus { get; set; }
        public string Insurance { get; set; }
        public string NumberOfMembers { get; set; }
        public string NumberOfMinors { get; set; }
        public bool IsHouseHoldEmployed { get; set; }
        public string ReceivingAny { get; set; }
        public string HouseHoldIncomeMonthly { get; set; }
        public string HouseHoldResources { get; set; }
        public string GeneralQuestions { get; set; }
        public string HealthConditions { get; set; }
        public string BeenInjured { get; set; }
        public string UpdatedNumberOfMembers { get; set; }
        public string UpdatedNumberOfMinors { get; set; }
        public string UpdatedMonthlyIncome { get; set; }
        public string UpdatedNumberOfResource { get; set; }
        public ContactSummary ContactSummary { get; set; }
    }

    public class ContactSummary
    {
        public string PersonalEmail { get; set; }
        public string PersonalCell { get; set; }
        public string PersonalCountyCode { get; set; }
        public string GuarantorEmail { get; set; }
        public string GuarantorCell { get; set; }
        public string GuarantorCountyCode { get; set; }
        public string PreferredCell { get; set; }
        public string PreferredEmail { get; set; }
        public string PreferredAddress { get; set; }
        public string PreferredCountyCode { get; set; }
    }
}
