namespace HealthWare.ActiveASSIST.DTOs.HealthWareServices
{
    public class AddressVerificationRequest
    {
        public int ObjectId { get; set; }
        public string ClientName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}
