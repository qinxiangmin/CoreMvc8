using Microsoft.AspNetCore.Antiforgery;
using CoreMvc8.Controllers;

namespace CoreMvc8.Web.Host.Controllers
{
    public class AntiForgeryController : CoreMvc8ControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
