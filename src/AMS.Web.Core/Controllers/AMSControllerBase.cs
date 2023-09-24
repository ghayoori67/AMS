using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AMS.Controllers
{
    public abstract class AMSControllerBase: AbpController
    {
        protected AMSControllerBase()
        {
            LocalizationSourceName = AMSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
