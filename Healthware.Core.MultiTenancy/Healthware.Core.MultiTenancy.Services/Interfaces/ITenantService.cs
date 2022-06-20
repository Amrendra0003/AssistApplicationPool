using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Healthware.Core.MultiTenancy.Entities;

namespace Healthware.Core.MultiTenancy.Services.Interfaces
{
    public interface ITenantService
    {
        public string GetDatabaseProvider();

        public string GetConnectionString();

        public Tenant GetTenant();
    }
}
