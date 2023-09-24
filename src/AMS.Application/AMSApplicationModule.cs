using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AMS.Authorization;

namespace AMS
{
    [DependsOn(
        typeof(AMSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AMSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AMSAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AMSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
