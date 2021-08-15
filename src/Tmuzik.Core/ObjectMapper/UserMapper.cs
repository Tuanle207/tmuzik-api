
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.ObjectMapper
{
    public class UserMapper : AutoMapper.Profile
    {
        public UserMapper()
        {
            CreateMap<User, AuthUser>()
                .ConstructUsing(src => new AuthUser
                {
                    Id = src.Id,
                    Email = src.Email,
                    Avatar = src.Profile.Avatar,
                    Dob = src.Profile.Dob,
                    FullName = src.Profile.FullName
                });
                    
            CreateMap<User, LoginResponseData>()
                .ConstructUsing(src => new LoginResponseData
                {
                    Id = src.Id,
                    Email = src.Email,
                    Avatar = src.Profile.Avatar,
                    Dob = src.Profile.Dob,
                    FullName = src.Profile.FullName
                });
        }
    }
}