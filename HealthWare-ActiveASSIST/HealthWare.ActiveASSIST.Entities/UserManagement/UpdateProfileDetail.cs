namespace HealthWare.ActiveASSIST.Entities.UserManagement
{
    public class UpdateProfileDetail
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string CountyCode { get; set; }
        public string Cell { get; set; }
        public string StreetAddress { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZipCode { get; set; }
        public string MailingAddressCountyCode { get; set; }
        public string MailingAddressCell { get; set; }
        public string IsDynamic { get; set; }
        
    }
}
