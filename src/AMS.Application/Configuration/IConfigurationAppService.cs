using System.Threading.Tasks;
using AMS.Configuration.Dto;

namespace AMS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
