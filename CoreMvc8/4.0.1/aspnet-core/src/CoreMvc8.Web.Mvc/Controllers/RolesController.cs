using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using CoreMvc8.Authorization;
using CoreMvc8.Controllers;
using CoreMvc8.Roles;
using CoreMvc8.Web.Models.Roles;

namespace CoreMvc8.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Roles)]
    public class RolesController : CoreMvc8ControllerBase
    {
        private readonly IRoleAppService _roleAppService;

        public RolesController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }

        public async Task<IActionResult> Index()
        {
            var roles = (await _roleAppService.GetAll(new PagedAndSortedResultRequestDto())).Items;
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new RoleListViewModel
            {
                Roles = roles,
                Permissions = permissions
            };

            return View(model);
        }

        public async Task<ActionResult> EditRoleModal(int roleId)
        {
            var output = await _roleAppService.GetRoleForEdit(new EntityDto(roleId));
            var model = new EditRoleModalViewModel(output);

            return View("_EditRoleModal", model);
        }

        public ActionResult GetJson()
        {
            var permissions =  _roleAppService.GetAllPermissions();
            return Json(permissions);
        }
    }
}
