using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using CoreMvc8.Controllers;

namespace CoreMvc8.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : CoreMvc8ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
