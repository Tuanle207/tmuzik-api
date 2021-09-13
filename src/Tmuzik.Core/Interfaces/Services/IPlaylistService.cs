using System;
using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;

namespace Tmuzik.Core.Interfaces.Services
{
    public interface IPlaylistService : IAppService
    {
        Task<GetUserPlaylistResponse> GetUserPlaylistsAsync(CancellationToken cancellationToken = default);
        Task<PlaylistDetail> GetPlaylistDetailAsync(Guid playlistId, CancellationToken cancellationToken = default);
        Task<CreatePlaylistResponse> CreatePlaylistAsync(CreatePlaylistRequest input, CancellationToken cancellationToken = default);
        Task<UpdatePlaylistResponse> UpdatePlaylistAsync(UpdatePlaylistRequest input, CancellationToken cancellationToken = default);
        Task RemovePlaylistAsync(Guid id, CancellationToken cancellationToken = default);
        Task<AddPlaylistItemResponse> AddPlaylistItemAsync(AddPlaylistItemRequest input, Guid playlistId, CancellationToken cancellationToken = default);
        Task RemovePlaylistItemAsync(RemovePlaylistItemRequest input, Guid playlistId, CancellationToken cancellationToken = default);

    }
}