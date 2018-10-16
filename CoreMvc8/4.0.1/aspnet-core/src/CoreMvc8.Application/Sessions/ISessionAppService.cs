using System.Threading.Tasks;
using Abp.Application.Services;
using CoreMvc8.Sessions.Dto;

namespace CoreMvc8.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
