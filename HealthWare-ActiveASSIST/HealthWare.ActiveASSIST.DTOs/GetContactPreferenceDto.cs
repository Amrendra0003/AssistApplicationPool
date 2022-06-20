namespace HealthWare.ActiveASSIST.DTOs
{
    public class GetContactPreferenceDto
    {
        public string ContactPreferenceId { get; set; }
        public string PreferedCellType { get; set; }
        public string CountyCode { get; set; }
        public string CellNumber { get; set; }
        public string TimeOfCalling { get; set; }
        public string EmailAddress { get; set; }
        public string ContactDetailsId { get; set; }
        public string PhoneId { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string County { get; set; }
        public string ModeOfCommunication { get; set; }
        public string PreferedCellUniqueId { get; set; }
        public string PreferedAddressUniqueId { get; set; }
        public string PreferedEmailUniqueId { get; set; }
        public string UniqueAddressId { get; set; }
        public string UniquePhoneId { get; set; }
        public string UniqueEmailId { get; set; }
    }
}
