using Abp.Authorization;
using AMS.Authorization.Roles;
using AMS.Authorization.Users;

namespace AMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
