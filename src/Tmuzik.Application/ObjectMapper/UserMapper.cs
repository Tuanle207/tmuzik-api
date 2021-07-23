using Tmuzik.Application.Dto.Users;
using Tmuzik.Data.Models;

namespace Tmuzik.Application.ObjectMapper
{
    public class UserMapper : AutoMapper.Profile
    {
        public UserMapper()
        {
            CreateMap<SignupRequest, User>();
        }
    }
}