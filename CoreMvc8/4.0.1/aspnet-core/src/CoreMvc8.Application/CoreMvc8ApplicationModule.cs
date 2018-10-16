using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CoreMvc8.Authorization;

namespace CoreMvc8
{
    [DependsOn(
        typeof(CoreMvc8CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CoreMvc8ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CoreMvc8AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CoreMvc8ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
