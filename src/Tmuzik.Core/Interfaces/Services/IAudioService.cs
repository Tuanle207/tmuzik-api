using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;

namespace Tmuzik.Core.Interfaces.Services
{
    public interface IAudioService : IAppService
    {
        Task<UploadAudioResponse> AddAudioAsync(UploadAudioRequest input, CancellationToken cancellationToken = default);
        Task<GetUserUploadAudioResponse> GetUserUploadAudioAsync(GetUserUploadAudioRequest input, CancellationToken cancellationToken = default);
    }
}