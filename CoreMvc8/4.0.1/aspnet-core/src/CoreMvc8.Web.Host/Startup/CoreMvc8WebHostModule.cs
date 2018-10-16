using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CoreMvc8.Configuration;

namespace CoreMvc8.Web.Host.Startup
{
    [DependsOn(
       typeof(CoreMvc8WebCoreModule))]
    public class CoreMvc8WebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CoreMvc8WebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CoreMvc8WebHostModule).GetAssembly());
        }
    }
}
