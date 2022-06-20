namespace HealthWare.ActiveASSIST.DTOs
{
    public class CreateContactPreference: BasePatientAssessment
    {
        public string CountyCode { get; set; }
        public string CellNumber { get; set; }
        public string PreferredCellType { get; set; }
        public string TimeOfCalling { get; set; }
        public string Email { get; set; }
        public long ContactEmailId { get; set; }
        public long ContactAddressId { get; set; }
        public long ContactPhoneId { get; set; }
        public string UniqueEmailId { get; set; }
        public string UniqueContactDetailsId { get; set; }
        public string UniquePhoneId { get; set; }
        public string Name { get; set; }
        public string Suite { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }
        public string ModeOfCommunication { get; set; }
    }
}
