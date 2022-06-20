namespace HealthWare.ActiveASSIST.DTOs
{
    public class GetTenantDetails
    {
        public long Id { get; set; }
        public string TenantName { get; set; }
        public string CellNumber { get; set; }
        public string CountyCode { get; set; }
        public string PublicKey { get; set; }
        public string UserKey { get; set; }
        public string TenantCode { get; set; }
        public string EmailAddress { get; set; }
    }
}
