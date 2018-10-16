using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CoreMvc8.Configuration.Dto;

namespace CoreMvc8.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CoreMvc8AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
