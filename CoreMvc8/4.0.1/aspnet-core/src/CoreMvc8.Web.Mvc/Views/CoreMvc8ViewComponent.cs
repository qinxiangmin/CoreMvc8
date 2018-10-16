using Abp.AspNetCore.Mvc.ViewComponents;

namespace CoreMvc8.Web.Views
{
    public abstract class CoreMvc8ViewComponent : AbpViewComponent
    {
        protected CoreMvc8ViewComponent()
        {
            LocalizationSourceName = CoreMvc8Consts.LocalizationSourceName;
        }
    }
}
