using System.Collections.Generic;
using CoreMvc8.Roles.Dto;
using CoreMvc8.Users.Dto;

namespace CoreMvc8.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
