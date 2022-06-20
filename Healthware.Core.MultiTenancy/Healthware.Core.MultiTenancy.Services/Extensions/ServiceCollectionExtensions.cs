using Healthware.Core.MultiTenancy.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Healthware.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Healthware.Core.MultiTenancy.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAndMigrateTenantDatabases<TK>(this IServiceCollection services, IConfiguration config) where TK : DbContext
        {
            var options = services.GetOptions<TenantSettings>(nameof(TenantSettings), config);
            var defaultConnectionString = options.Defaults?.ConnectionString;
            var defaultDbProvider = options.Defaults?.DBProvider;
            if (defaultDbProvider != null && defaultDbProvider.ToLower() == "mssql")
            {
                services.AddDbContext<TK>(m => m.UseSqlServer(e => e.MigrationsAssembly(typeof(TK).Assembly.FullName)));
            }
            var tenants = options.Tenants;
            foreach (var tenant in tenants)
            {
                var path = @"C:\inetpub\wwwroot\ActiveASSISTUserImport\";
                DirectoryInfo di = Directory.CreateDirectory(path + tenant.TID);
                Directory.CreateDirectory(di.FullName + "\\ProcessedFiles");
                Directory.CreateDirectory(di.FullName + "\\FailedFiles");
            }
            
            foreach (var connectionString in tenants.Select(tenant => string.IsNullOrEmpty(tenant.ConnectionString) ? defaultConnectionString : tenant.ConnectionString))
            {
                using var scope = services.BuildServiceProvider().CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<TK>();
                dbContext.Database.SetConnectionString(connectionString);
                if (dbContext.Database.GetMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }
            }
            return services;
        }

        public static T GetOptions<T>(this IServiceCollection services, string sectionName, IConfiguration config) where T : new()
        {
            //using var serviceProvider = services.BuildServiceProvider();
            //var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var section = config.GetSection(sectionName);
            var options = new T();
            section.Bind(options);
            return options;
        }
    }
}
