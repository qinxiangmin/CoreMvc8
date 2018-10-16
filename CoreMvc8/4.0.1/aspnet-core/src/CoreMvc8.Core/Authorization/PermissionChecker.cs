using Abp.Authorization;
using CoreMvc8.Authorization.Roles;
using CoreMvc8.Authorization.Users;

namespace CoreMvc8.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
