namespace HealthWare.ActiveASSIST.DTOs.Authentication
{
    public class AuthenticateResponse : BaseUserAccountDetails
    {
        public string TenantId { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string ContactNumber { get; set; }
        public long PatientId { get; set; }
        public string SignedInFirstName { get; set; }
        public string SignedInLastName { get; set; }
        public long UserId { get; set; }
        public string CountryCode { get; set; }
        public bool IsOTPEnabled { get; set; }
    }
}