//using HealthWare.Core.Entities;
//using Healthware.Core.MultiTenancy.Entities.Interfaces;
//using Healthware.Core.MultiTenancy.Entities;
//using Healthware.Core.MultiTenancy.Services.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using HealthWare.Core.Containers;

//namespace Healthware.Core.MultiTenancy.Services
//{
//    public class TenantDbContext : DbContext
//    {

//        public string TenantId { get; set; }
//        private readonly ITenantService _tenantService;

//        public TenantDbContext(DbContextOptions options) : base(options)
//        {
//            _tenantService = Resolve.AnImplementationOf<ITenantService>();
//            TenantId = _tenantService.GetTenant()?.TID;
//        }

//        public TenantDbContext(DbContextOptions options, ITenantService tenantService) : base(options)
//        {
//            _tenantService = tenantService;
//            TenantId = _tenantService.GetTenant()?.TID;
//        }



//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            var tenantConnectionString = _tenantService.GetConnectionString();
//            if (!string.IsNullOrEmpty(tenantConnectionString))
//            {
//                var dbProvider = _tenantService.GetDatabaseProvider();
//                if (dbProvider.ToLower() == "mssql")
//                {
//                    optionsBuilder.UseSqlServer(_tenantService.GetConnectionString());
//                }
//            }
//        }

//        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
//        {
//            foreach (var entry in ChangeTracker.Entries<ITenantInterface>().ToList())
//            {
//                switch (entry.State)
//                {
//                    case EntityState.Added:
//                    case EntityState.Modified:
//                        entry.Entity.TenantId = TenantId;
//                        break;
//                }
//            }

//            var result = await base.SaveChangesAsync(cancellationToken);
//            return result;
//        }

//    }
//}
