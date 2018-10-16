using System.Collections.Generic;
using CoreMvc8.Roles.Dto;

namespace CoreMvc8.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}