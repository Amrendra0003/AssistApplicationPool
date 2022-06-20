using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthware.Core.MultiTenancy.Entities.Interfaces
{
    public interface ITenantInterface
    {
        string TenantId { get; set; }
    }
}
