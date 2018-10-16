using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CoreMvc8.MultiTenancy.Dto;

namespace CoreMvc8.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
