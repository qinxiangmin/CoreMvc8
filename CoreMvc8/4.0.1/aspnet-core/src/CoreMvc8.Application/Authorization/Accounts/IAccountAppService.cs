using System.Threading.Tasks;
using Abp.Application.Services;
using CoreMvc8.Authorization.Accounts.Dto;

namespace CoreMvc8.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
