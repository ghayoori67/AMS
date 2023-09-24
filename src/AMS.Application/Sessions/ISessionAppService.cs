using System.Threading.Tasks;
using Abp.Application.Services;
using AMS.Sessions.Dto;

namespace AMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
