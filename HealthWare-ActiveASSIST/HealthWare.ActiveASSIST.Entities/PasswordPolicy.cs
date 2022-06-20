using Healthware.Core.Entities;
using Healthware.Core.MultiTenancy.Entities.Interfaces;

namespace HealthWare.ActiveASSIST.Entities
{
    public class PasswordPolicy : BaseEntity, ITenantInterface
    {
        public int AttemptLimits { get; set; }
        public string ExpireTime { get; set; }
        public string Pattern { get; set; }
        public string TenantId { get; set; }
        public int MaximumLength { get; set; }
        public int MinimumLength { get; set; }
    }
}
