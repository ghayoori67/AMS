using System.Threading.Tasks;
using Abp.Application.Services;
using AMS.Authorization.Accounts.Dto;

namespace AMS.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
