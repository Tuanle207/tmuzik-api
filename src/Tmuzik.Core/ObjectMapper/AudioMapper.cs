using System.Linq;
using System.Text.Json;
using AutoMapper;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.ObjectMapper
{
    public class AudioMapper : Profile
    {
        public AudioMapper()
        {
            CreateMap<Artist, SimpleArtist>()
                .ConvertUsing(src => MapArtistToSimpleArtist(src));

            CreateMap<UploadAudioRequest, Audio>()
                .ConvertUsing(src => MapUploadAudioRequestToAudio(src));

            CreateMap<Audio, UploadAudioResponse>()
                .ConvertUsing(src => MapAudioToAudioResponse(src));

            CreateMap<Audio, UserUploadAudio>()
                .ConvertUsing(src => MapAudioToUserUploadAudio(src));
        }

        private Audio MapUploadAudioRequestToAudio(UploadAudioRequest src)
        {
            var result = new Audio
            {
                Name = src.Name,
                Artists = src.Artists,
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
                Artists = src.Artists,
                Length = src.Length,
                Privacy = src.Privacy,
                File = src.File,
                Description = src.Description,
                Genre = src.Genre
            };
            return result;
        }

        private UserUploadAudio MapAudioToUserUploadAudio(Audio src)
        {
            var result = new UserUploadAudio
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
                Artists = src.Artists,
                Artist = MapArtistToSimpleArtist(src.Artist),
                AlbumTag = src.AlbumTag,
                Cover = src.Cover,
                File = src.File,
                Genre = src.Genre,
                Length = src.Length,
                Privacy = src.Privacy,
                CreationTime = src.CreationTime
            };
            return result;
        }

        private SimpleArtist MapArtistToSimpleArtist(Artist src)
        {
            if (src == null) return null;
            var result = new SimpleArtist
            {
                Id = src.Id,
                Name = src.Name,
                Avatar = src.Avatar
            };
            return result;
        }

    }
}