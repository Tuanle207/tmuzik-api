using System;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.ObjectMapper
{
    public partial class AutoMapperProfile
    {
        private void CreateArtistMaps()
        {
            CreateMap<Artist, ArtistInfo>()
                .ConvertUsing(src => MapArtistToArtistInfo(src));
        }

        private ArtistInfo MapArtistToArtistInfo(Artist src)
        {
            var result = new ArtistInfo
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
                Avatar = src.Avatar,
                Cover = src.Cover,
                Photo = src.Photo,
                Follows = src.Follows,
                Plays = src.Plays,
                FacebookUrl = src.FacebookUrl,
                InstagramUrl = src.InstagramUrl,
                TwitterUrl = src.TwitterUrl,
                YoutubeUrl = src.YoutubeUrl,
                Verified = src.Verified,
                CreationTime = src.CreationTime
            };
            return result;
        }
    }
}