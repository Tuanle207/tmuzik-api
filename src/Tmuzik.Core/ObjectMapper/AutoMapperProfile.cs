using AutoMapper;

namespace Tmuzik.Core.ObjectMapper
{
    public partial class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateUtilMaps();
            CreateAudioMaps();
            CreatePlaylistMaps();
            CreateUserMaps();
        }
    }
}