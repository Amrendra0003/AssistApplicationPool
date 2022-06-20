using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthware.Core.MultiTenancy.Entities
{
    public class SubDomainMaster
    {
        public long Id { get; set; }
        public string SubDomain { get; set; }
        public string TenantId { get; set; }

    }
}
