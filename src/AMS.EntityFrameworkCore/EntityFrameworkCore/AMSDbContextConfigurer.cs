using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AMS.EntityFrameworkCore
{
    public static class AMSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AMSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AMSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
