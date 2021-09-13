using System;
using System.Collections.Generic;
using AutoMapper;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.ObjectMapper
{
    public partial class AutoMapperProfile
    {
        public void CreatePlaylistMaps()
        {
            CreateMap<CreatePlaylistRequest, Playlist>()
                .ConvertUsing(src => MapCreatePlaylistRequestToPlaylist(src));

            CreateMap<Playlist, CreatePlaylistResponse>()
                .ConvertUsing(src => MapPlaylistToCreatePlaylistResponse(src));

            CreateMap<Playlist, UpdatePlaylistResponse>()
                .ConvertUsing(src => MapPlaylistToUpdatePlaylistResponse(src));
            
            CreateMap<Playlist, UserPlaylist>()
                .ConvertUsing(src => MapPlaylistToUserPlaylist(src));

            CreateMap<Playlist, PlaylistDetail>()
                .ConvertUsing(src => MapPlaylistToPlaylistDetail(src));

            CreateMap<PlaylistItem, AudioItem>()
                .ConvertUsing(src => MapPlaylistItemToAudioItem(src));
                
        }

        private PlaylistDetail MapPlaylistToPlaylistDetail(Playlist src)
        {
            var mappedItems = new List<AudioItem>();
            
            foreach (var item in src.Items)
            {
                var mappedItem = MapPlaylistItemToAudioItem(item);
                if (mappedItem != null) mappedItems.Add(mappedItem);
            }
            
            var result = new PlaylistDetail
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
                Cover = src.Cover,
                CreationTime = src.CreationTime,
                Privacy = src.Privacy,
                Items = mappedItems,
                Creator = MapUserProfileToCreator(src.Creator)
            };
            return result;
        }

        private UserPlaylist MapPlaylistToUserPlaylist(Playlist src)
        {
            var result = new UserPlaylist
            {
                Id = src.Id,
                Description = src.Description,
                Name = src.Name,
                Cover = src.Cover
            };
            return result;
        }

        private UpdatePlaylistResponse MapPlaylistToUpdatePlaylistResponse(Playlist src)
        {
            var result = new UpdatePlaylistResponse
            {
                Id = src.Id,
                Cover = src.Cover,
                Name = src.Name,
                Description = src.Description
            };
            return result;
        }

        private CreatePlaylistResponse MapPlaylistToCreatePlaylistResponse(Playlist src)
        {
            var result = new CreatePlaylistResponse
            {
                Id = src.Id,
                Cover = src.Cover,
                Name = src.Name,
                Description = src.Description
            };
            return result;
        }

        private Playlist MapCreatePlaylistRequestToPlaylist(CreatePlaylistRequest src)
        {
            var result = new Playlist
            {
                Name = src.Name,
                Description = src.Description
            };
            return result;
        }

        // Utils mappers
        private AudioItem MapPlaylistItemToAudioItem(PlaylistItem src)
        {
            if (src == null || src.Audio == null) return null;
            var result = MapAudioToAudioItem(src.Audio);
            return result;
        }
    }
}