using System.Threading.Tasks;
using CoreMvc8.Configuration.Dto;

namespace CoreMvc8.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
