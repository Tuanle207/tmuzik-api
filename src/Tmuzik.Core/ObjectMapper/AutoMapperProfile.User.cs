
using System;
using AutoMapper;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.ObjectMapper
{
    public partial class AutoMapperProfile
    {
        public void CreateUserMaps()
        {
            CreateMap<User, AuthUser>()
                .ConvertUsing(src => MapUserToAuthUser(src));
                    
            CreateMap<User, LoginResponseData>()
                .ConvertUsing(src => MapUserToLoginResponseData(src));

            CreateMap<UserProfile, UserInfo>()
                .ConvertUsing(src => MapUserProfileToUserInfo(src));

            CreateMap<UserProfile, SimpleUserProfile>()
                .ConvertUsing(src => MapUserProfileToSimpleUserProfile(src));
        }

        private SimpleUserProfile MapUserProfileToSimpleUserProfile(UserProfile src)
        {
            var result = new SimpleUserProfile
            {
                Id = src.UserId,
                Name = src.FullName,
                Avatar = src.Avatar
            };

            return result;
        }

        private UserInfo MapUserProfileToUserInfo(UserProfile src)
        {
            var result = new UserInfo
            {
                Id = src.UserId,
                ProfileId = src.Id,
                FullName = src.FullName,
                Avatar = src.Avatar,
                Cover = src.Cover,
                Dob = src.Dob,
            };

            return result;
        }

        private AuthUser MapUserToAuthUser(User src)
        {
            var result = new AuthUser
            {
                Id = src.Id,
                Email = src.Email,
                CreationTime = src.CreationTime,
                Verified = src.Verified,
                Profile = new AuthUserProfile
                {
                    Id = src.Profile.Id,
                    FullName = src.Profile.FullName,
                    Dob = src.Profile.Dob,
                    Avatar = src.Profile.Avatar,
                    Cover = src.Profile.Cover,
                    IsArtist = src.Profile.IsArtist,
                    IsPremium = src.Profile.IsPremium
                }
            };
            return result;
        }

        private LoginResponseData MapUserToLoginResponseData(User src)
        {
            var result = new LoginResponseData
            {
                Id = src.Id,
                ProfileId = src.Profile.Id,
                Email = src.Email,
                Verified = src.Verified,
                CreationTime = src.CreationTime,
                FullName = src.Profile.FullName,
                Dob = src.Profile.Dob,
                Avatar = src.Profile.Avatar,
                Cover = src.Profile.Cover,
                IsPremium = src.Profile.IsPremium,
                IsArtist = src.Profile.IsArtist
            };
            return result;
        }
    }
}