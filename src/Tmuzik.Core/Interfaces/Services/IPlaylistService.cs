using System;
using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;

namespace Tmuzik.Core.Interfaces.Services
{
    public interface IPlaylistService : IAppService
    {
        Task<GetUserPlaylistResponse> GetUserPlaylists(CancellationToken cancellationToken = default);
        Task<GetUserPlaylistDetailResponse> GetUserPlaylistDetail(Guid id, CancellationToken cancellationToken = default);
        Task<CreatePlaylistResponse> CreatePlaylist(CreatePlaylistRequest input, CancellationToken cancellationToken = default);
        Task<UpdatePlaylistResponse> UpdatePlaylist(UpdatePlaylistRequest input, CancellationToken cancellationToken = default);
        Task RemovePlaylist(Guid id, CancellationToken cancellationToken = default);
        Task AddPlaylistItem(AddPlaylistItemRequest input, CancellationToken cancellationToken = default);
        Task RemovePlaylistItem(RemovePlaylistItemRequest input, CancellationToken cancellationToken = default);

    }
}