using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using CoreMvc8.Configuration;
using CoreMvc8.Web;

namespace CoreMvc8.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CoreMvc8DbContextFactory : IDesignTimeDbContextFactory<CoreMvc8DbContext>
    {
        public CoreMvc8DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CoreMvc8DbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CoreMvc8DbContextConfigurer.Configure(builder, configuration.GetConnectionString(CoreMvc8Consts.ConnectionStringName));

            return new CoreMvc8DbContext(builder.Options);
        }
    }
}
