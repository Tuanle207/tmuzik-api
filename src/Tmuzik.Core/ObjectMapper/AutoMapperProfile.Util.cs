using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.ObjectMapper
{
    public partial class AutoMapperProfile
    {
        
        private void CreateUtilMaps()
        {
            CreateMap<Artist, SimpleArtist>()
                .ConvertUsing(src => MapArtistToSimpleArtist(src));
            
            CreateMap<Album, SimpleAlbum>()
                .ConvertUsing(src => MapAlbumToSimpleAlbum(src));
            
            CreateMap<UserProfile, Creator>()
                .ConvertUsing(src => MapUserProfileToCreator(src));
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

        private SimpleAlbum MapAlbumToSimpleAlbum(Album src)
        {
            if (src == null) return null;
            var result = new SimpleAlbum
            {
                Id = src.Id,
                Name = src.Name,
                Description = src.Description,
                Cover = src.Cover,
                CreationTime = src.CreationTime
            };
            return result;
        }

        private Creator MapUserProfileToCreator(UserProfile src)
        {
            if (src == null) return null;
            var result = new Creator
            {
                Id = src.Id,
                FullName = src.FullName,
                Avatar = src.Avatar,
                IsArtist = src.IsArtist
            };
            return result;
        }
    }
}