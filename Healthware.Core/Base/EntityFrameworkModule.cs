using Healthware.Core.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Healthware.Core.Base
{

    public class EntityFrameworkModule<TK> where TK : DbContext
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        private readonly IConfigurationRoot _appConfiguration;
        private readonly TK _moduleDbContext;

        public EntityFrameworkModule(IConfigurationRoot appConfiguration, TK moduleDbContext)
        {
            _appConfiguration = appConfiguration;
            _moduleDbContext = moduleDbContext;
        }

        public void Initialize()
        {
            var builder = new DbContextOptionsBuilder<TK>();
            DbContextConfigurer<TK>.Configure(builder, _appConfiguration.GetConnectionString(Portal.ConnectionStringName));
        }
    }
}
