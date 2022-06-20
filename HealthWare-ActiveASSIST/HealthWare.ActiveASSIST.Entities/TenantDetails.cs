using Healthware.Core.Entities;
using HealthWare.ActiveASSIST.DTOs;

namespace HealthWare.ActiveASSIST.Entities
{
    public class TenantDetails : BaseEntity
    {
        public string TenantName { get; set; }
        public string PhoneNumber { get; set; }
        public string CountyCode { get; set; }
        public string PublicKey { get; set; }
        public string UserKey { get; set; }
        public string TenantCode { get; set; }
        public string EmailAddress { get; set; }

        public static implicit operator GetTenantDetails(TenantDetails tenantDetails)
        {
            return new GetTenantDetails()
            {
                Id = tenantDetails.Id,
                TenantName = tenantDetails.TenantName,
                CellNumber = tenantDetails.PhoneNumber,
                CountyCode = tenantDetails.CountyCode,
                PublicKey = tenantDetails.PublicKey,
                UserKey = tenantDetails.UserKey,
                TenantCode = tenantDetails.TenantCode,
                EmailAddress = tenantDetails.EmailAddress
            };
        }
    }
}
