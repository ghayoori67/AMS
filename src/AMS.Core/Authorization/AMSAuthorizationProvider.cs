using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace AMS.Authorization
{
    public class AMSAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Ticket, L("Tickets"));
            context.CreatePermission(PermissionNames.Pages_Tickets_Admin, L("AdminTickets"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AMSConsts.LocalizationSourceName);
        }
    }
}
