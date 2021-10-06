using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;

namespace Tmuzik.Core.Interfaces.Services
{
    public interface IDashboardService : IAppService
    {
        Task<GetSearchResultsResponse> GetSearchResultsAsync(GetSearchResultsRequest input, CancellationToken cancellationToken = default);
    }
}