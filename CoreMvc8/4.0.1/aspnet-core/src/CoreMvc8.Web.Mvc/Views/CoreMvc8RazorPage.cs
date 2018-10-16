using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace CoreMvc8.Web.Views
{
    public abstract class CoreMvc8RazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected CoreMvc8RazorPage()
        {
            LocalizationSourceName = CoreMvc8Consts.LocalizationSourceName;
        }
    }
}
