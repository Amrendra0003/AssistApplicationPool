using Healthware.Core.MultiTenancy.Entities.Interfaces;
using Healthware.Core.Entities;

namespace Healthware.Core.MultiTenancy.Entities
{
    public class User : MainUser, ITenantInterface
    {
        public string TenantId { get; set; }

    }
}
