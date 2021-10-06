using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Contract.Requests;

namespace Tmuzik.Core.Interfaces.Services
{
    public interface IArtistService : IAppService
    {
        Task<ArtistInfo> ClaimArtistAsync(ClaimArtistRequest input, CancellationToken cancellationToken = default);
    }
}