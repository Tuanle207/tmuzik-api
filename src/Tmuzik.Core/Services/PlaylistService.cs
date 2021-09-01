using System;
using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;
using Tmuzik.Core.Interfaces;
using Tmuzik.Core.Interfaces.Services;
using Tmuzik.Core.Specifications.Playlists;

namespace Tmuzik.Core.Services
{
    public class PlaylistService : AppService, IPlaylistService
    {
        private readonly IStorageHandler _storageHandler;

        public PlaylistService(IServiceProvider serviceProvider, IStorageHandler storageHandler) 
            : base(serviceProvider)
        {
            _storageHandler = storageHandler;
        }

        public async Task<GetUserPlaylistDetailResponse> GetUserPlaylistDetailAsync(Guid playlistId, CancellationToken cancellationToken = default)
        {
            var userProfileId = CurrentUser.ProfileId.Value;

            var userPlaylistSpec = new PlaylistSpecification(playlistId, userProfileId);
            var userPlaylistSelector = UnitOfWork.Playlists.CreateSelector(x => Mapper.Map<GetUserPlaylistDetailResponse>(x));

            var result = await UnitOfWork.Playlists.FirstOrDefaultAsync(userPlaylistSpec, userPlaylistSelector, cancellationToken);
            return result;
        }

        public async Task<GetUserPlaylistResponse> GetUserPlaylistsAsync(CancellationToken cancellationToken = default)
        {
            var userProfileId = CurrentUser.ProfileId.Value;
            
            var userPlaylistSpec = new PlaylistSpecification(userProfileId);
            var userPlaylistSelector = UnitOfWork.Playlists.CreateSelector(x => Mapper.Map<UserPlaylist>(x));
            var items = await UnitOfWork.Playlists.ListAsync(userPlaylistSpec, userPlaylistSelector, cancellationToken);

            var result = new GetUserPlaylistResponse
            {
                Items = items,
                TotalCount = items.Count
            };
            return result;
        }
        
        public async Task<UpdatePlaylistResponse> UpdatePlaylistAsync(UpdatePlaylistRequest input, CancellationToken cancellationToken = default)
        {
            var playlist = await UnitOfWork.Playlists.GetByIdAsync(input.Id, cancellationToken);

            playlist.Name = input.Name;
            playlist.Description = playlist.Description;
            if (input.Cover != null)
            {
                if (!String.IsNullOrEmpty(playlist.Cover)) {
                    await _storageHandler.RemoveFileAsync(playlist.Cover);
                }

                var url = await _storageHandler.SaveFileAsync(input.Cover);
                playlist.Cover = url;
            }

            await UnitOfWork.Playlists.UpdateAsync(playlist, cancellationToken);

            var result = Mapper.Map<UpdatePlaylistResponse>(playlist);
            return result;
        }

        public async Task<CreatePlaylistResponse> CreatePlaylistAsync(CreatePlaylistRequest input, CancellationToken cancellationToken = default)
        {
            var playlist = Mapper.Map<Playlist>(input);
            var userProfileId = CurrentUser.ProfileId.Value;
            playlist.CreatorId = userProfileId;

            if (input.Cover != null)
            {
                var url = await _storageHandler.SaveFileAsync(input.Cover);
                playlist.Cover = url;
            }

            playlist = await UnitOfWork.Playlists.AddAsync(playlist);

            var result = Mapper.Map<CreatePlaylistResponse>(playlist);
            return result;
        }

        public async Task RemovePlaylistAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var playlist = await UnitOfWork.Playlists.GetByIdAsync(id, cancellationToken);

            if (!String.IsNullOrEmpty(playlist.Cover)) 
            {
                await _storageHandler.RemoveFileAsync(playlist.Cover);
            }

            var itemsByPlaylistIdSpec = new PlaylistItemsByPlaylistSpecification(id);
            var items = await UnitOfWork.PlaylistItems.ListAsync(itemsByPlaylistIdSpec);
            foreach (var item in items)
            {
                UnitOfWork.PlaylistItems.Delete(item);
            }

            UnitOfWork.Playlists.Delete(playlist);

            await UnitOfWork.CommitAsync();
        }

        public async Task AddPlaylistItemAsync(AddPlaylistItemRequest input, Guid playlistId, CancellationToken cancellationToken = default)
        {
            foreach (var itemId in input.Items)
            {
                var playlistItem = new PlaylistItem
                {
                    AudioId = itemId,
                    PlaylistId = playlistId
                };

                UnitOfWork.PlaylistItems.Add(playlistItem);
            }

            await UnitOfWork.CommitAsync();
        }

        public async Task RemovePlaylistItemAsync(RemovePlaylistItemRequest input, Guid playlistId, CancellationToken cancellationToken = default)
        {
            foreach (var itemId in input.Items)
            {
                var playlistItem = new PlaylistItem
                {
                    AudioId = itemId,
                    PlaylistId = playlistId
                };

                UnitOfWork.PlaylistItems.Delete(playlistItem);
            }

            await UnitOfWork.CommitAsync();
        }

    }
}