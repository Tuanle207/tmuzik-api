using Tmuzik.Application.Dto.Requests;
using Tmuzik.Application.Dto.Responses;
using Tmuzik.Data.Models;
using Tmuzik.Infrastructure.Models;

namespace Tmuzik.Application.ObjectMapper
{
    public class UserMapper : AutoMapper.Profile
    {
        public UserMapper()
        {
            CreateMap<SignupRequest, User>();
            CreateMap<User, AuthDto>();
            CreateMap<User, LoginReponse>();
        }
    }
}