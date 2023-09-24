using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AMS.Configuration.Dto;

namespace AMS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AMSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
