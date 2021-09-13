using System;
using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Common.Consts;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;
using Tmuzik.Core.Exceptions;
using Tmuzik.Core.Interfaces;
using Tmuzik.Core.Interfaces.Services;
using Tmuzik.Core.Specifications.Audios;
using Tmuzik.Core.Specifications.Playlists;

namespace Tmuzik.Core.Services
{
    public class PlaylistService : AppService, IPlaylistService
    {
        private readonly IStorageHandler _storageHandler;

        public PlaylistService(IServiceProvider serviceProvider, IStorageHandler storageHandler, 
            IAccessPermissionManager accessPermissionManager) 
            : base(serviceProvider)
        {
            _storageHandler = storageHandler;
        }

        public async Task<PlaylistDetail> GetPlaylistDetailAsync(Guid playlistId, CancellationToken cancellationToken = default)
        {
            var userPlaylistSpec = new PlaylistSpecification(playlistId);
            var userPlaylistSelector = UnitOfWork.Playlists.CreateSelector(x => Mapper.Map<PlaylistDetail>(x));

            var result = await UnitOfWork.Playlists.FirstOrDefaultAsync(userPlaylistSpec, userPlaylistSelector, cancellationToken);
            
            if (!await AccessPermissionManager.CheckUserAccessPermission(ResourceType.Playlist, result.Id))
            {
                throw ExceptionBuilder.Build(CoreExceptions.Forbidden);
            };

            return result;
        }

        public async Task<GetUserPlaylistResponse> GetUserPlaylistsAsync(CancellationToken cancellationToken = default)
        {
            var userProfileId = CurrentUser.ProfileId.Value;
            
            var userPlaylistSpec = new UserPlaylistSpecification(userProfileId);
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
            playlist.Description = input.Description;
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

        public async Task<AddPlaylistItemResponse> AddPlaylistItemAsync(AddPlaylistItemRequest input, Guid playlistId, CancellationToken cancellationToken = default)
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

            var audioSpec = new AudioIncludesFieldsSpecification(input.Items);
            var audioSelector = UnitOfWork.Audios.CreateSelector(x => Mapper.Map<AudioItem>(x));
            var items = await UnitOfWork.Audios.ListAsync(audioSpec, audioSelector);

            var result = new AddPlaylistItemResponse
            {
                Items = items
            };
            return result;
        }

        public async Task RemovePlaylistItemAsync(RemovePlaylistItemRequest input, Guid playlistId, CancellationToken cancellationToken = default)
        {
            var playlistItemSpec = new PlaylistItemSpecification(input.Items, playlistId);
            var items = await UnitOfWork.PlaylistItems.ListAsync(playlistItemSpec);
            foreach (var item in items)
            {
                UnitOfWork.PlaylistItems.Delete(item);
            }

            await UnitOfWork.CommitAsync();
        }

    }
}