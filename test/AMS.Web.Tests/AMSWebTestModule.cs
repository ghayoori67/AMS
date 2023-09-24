using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AMS.EntityFrameworkCore;
using AMS.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AMS.Web.Tests
{
    [DependsOn(
        typeof(AMSWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AMSWebTestModule : AbpModule
    {
        public AMSWebTestModule(AMSEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AMSWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AMSWebMvcModule).Assembly);
        }
    }
}