using System;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.ObjectMapper
{
    public partial class AutoMapperProfile
    {
        private void CreateAudioMaps()
        {
            CreateMap<UploadAudioRequest, Audio>()
                .ConvertUsing(src => MapUploadAudioRequestToAudio(src));

            CreateMap<Audio, UploadAudioResponse>()
                .ConvertUsing(src => MapAudioToAudioResponse(src));

            // CreateMap<Audio, UserUploadAudio>()
            //     .ConvertUsing(src => MapAudioToUserUploadAudio(src));

            CreateMap<Audio, AudioItem>()
                .ConvertUsing(src => MapAudioToAudioItem(src));
        }

        private AudioItem MapAudioToAudioItem(Audio src)
        {
            if (src == null) return null;
            var result = new AudioItem
            {
                Id = src.Id,
                Name = src.Name,
                Length = src.Length,
                Description = src.Description,
                Cover = src.Cover,
                AlbumTag = src.AlbumTag,
                Album = MapAlbumToSimpleAlbum(src.Album),
                Artist = MapArtistToSimpleArtist(src.Artist),
                ArtistTag = src.ArtistTag,
                CreationTime = src.CreationTime,
                Creator = MapUserProfileToCreator(src.UploadedBy),
                File = src.File,
                Genre = src.Genre,
                Privacy = src.Privacy,
                Loves = src.Loves,
                Plays = src.Plays
            };
            return result;
        }

        private Audio MapUploadAudioRequestToAudio(UploadAudioRequest src)
        {
            var result = new Audio
            {
                Name = src.Name,
                ArtistTag = src.Artists,
                AlbumTag = src.AlbumTag,
                Description = src.Description,
                Length = src.Length,
                Genre = src.Genre,
                Privacy = src.Privacy,
            };
            return result;
        }

        private UploadAudioResponse MapAudioToAudioResponse(Audio src)
        {
            var result = new UploadAudioResponse
            {
                Id = src.Id,
                Name = src.Name,
                Cover = src.Cover,
                AlbumTag = src.AlbumTag,
                Artists = src.ArtistTag,
                Length = src.Length,
                Privacy = src.Privacy,
                File = src.File,
                Description = src.Description,
                Genre = src.Genre
            };
            return result;
        }

        // private UserUploadAudio MapAudioToUserUploadAudio(Audio src)
        // {
        //     var result = new UserUploadAudio
        //     {
        //         Id = src.Id,
        //         Name = src.Name,
        //         Description = src.Description,
        //         Artists = src.ArtistTag,
        //         Artist = MapArtistToSimpleArtist(src.Artist),
        //         AlbumTag = src.AlbumTag,
        //         Cover = src.Cover,
        //         File = src.File,
        //         Genre = src.Genre,
        //         Length = src.Length,
        //         Privacy = src.Privacy,
        //         CreationTime = src.CreationTime
        //     };
        //     return result;
        // }
    }
}