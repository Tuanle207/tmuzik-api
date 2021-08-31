using System;
using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Interfaces.Services;

namespace Tmuzik.Core.Services
{
    public class PlaylistService : AppService, IPlaylistService
    {
        public PlaylistService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        public async Task AddPlaylistItem(AddPlaylistItemRequest input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<CreatePlaylistResponse> CreatePlaylist(CreatePlaylistRequest input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserPlaylistDetailResponse> GetUserPlaylistDetail(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserPlaylistResponse> GetUserPlaylists(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task RemovePlaylist(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task RemovePlaylistItem(RemovePlaylistItemRequest input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdatePlaylistResponse> UpdatePlaylist(UpdatePlaylistRequest input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}