using System.ComponentModel.DataAnnotations;
using Healthware.Core.MultiTenancy.Entities;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class BulkUserUpload
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [RegularExpression(@"^(1)$", ErrorMessage = "Invalid country code.")]
        public string CountyCode { get; set; }
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid mobile number.")]
        public string Cell { get; set; }
        [EmailAddress]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        public string TenantId { get; set; }

        public static implicit operator User(BulkUserUpload bulkUser)
        {
            return new User()
            {
                FirstName = bulkUser.FirstName,
                LastName = bulkUser.LastName,
                CountyCode = bulkUser.CountyCode,
                Cell = bulkUser.Cell,
                EmailAddress = bulkUser.EmailAddress,
                TenantId = bulkUser.TenantId,
            };
        }
    }
}
