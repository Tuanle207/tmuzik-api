using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;

namespace Tmuzik.Core.Interfaces.Services
{
    public interface IArtistService : IAppService
    {
        Task<ClaimArtistResponse> ClaimArtistAsync(ClaimArtistRequest input, CancellationToken cancellationToken = default);
    }
}