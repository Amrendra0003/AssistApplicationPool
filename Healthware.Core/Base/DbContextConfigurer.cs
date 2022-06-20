using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Healthware.Core.Base
{
    public static class DbContextConfigurer<TK> where TK : DbContext
    {
        public static void Configure(DbContextOptionsBuilder<TK> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TK> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
