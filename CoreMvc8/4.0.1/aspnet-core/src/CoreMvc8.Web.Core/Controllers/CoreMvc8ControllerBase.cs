using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CoreMvc8.Controllers
{
    public abstract class CoreMvc8ControllerBase: AbpController
    {
        protected CoreMvc8ControllerBase()
        {
            LocalizationSourceName = CoreMvc8Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
