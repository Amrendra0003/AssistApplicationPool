namespace Healthware.Core.Enumerators
{
    public class CoreEnums
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
            UserProfile = 9
        }

        public enum RecordStatus : long
        {
            Deleted,
            Active,
            InActive
        }
    }

}
