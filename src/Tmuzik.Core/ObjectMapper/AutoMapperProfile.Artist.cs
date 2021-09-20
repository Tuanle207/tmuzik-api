using System;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.ObjectMapper
{
    public partial class AutoMapperProfile
    {
        private void CreateArtistMaps()
        {
            CreateMap<Artist, ClaimArtistResponse>()
                .ConvertUsing(src => MapArtistToClaimArtistResponse(src));
        }

        private ClaimArtistResponse MapArtistToClaimArtistResponse(Artist src)
        {
            var result = new ClaimArtistResponse
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
                Verified = src.Verified
            };
            return result;
        }
    }
}