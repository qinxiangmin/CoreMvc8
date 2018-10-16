using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CoreMvc8.EntityFrameworkCore
{
    public static class CoreMvc8DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CoreMvc8DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CoreMvc8DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
