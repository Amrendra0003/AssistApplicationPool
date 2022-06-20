namespace HealthWare.ActiveASSIST.Entities
{
    public class Enums
    {
        public enum ContactType
        {
            SelfBasic = 1,
            SelfHome = 2,
            SelfWork = 3,
            GuarantorBasic = 4,
            GuarantorHome = 5,
            GuarantorWork = 6,
            HouseHoldIncome = 7,
            Other = 8,
            UserProfile = 9,
            SecondaryEmail = 10
        }
        public enum AssessmentStatus
        {
            Incomplete = 1,
            DocumentationIncomplete = 2,
            VerificationPending = 3,
            Completed = 4
        }
        public enum RecordStatus:long
        {
            Deleted,
            Active,
            InActive
        }
    }

    
}
