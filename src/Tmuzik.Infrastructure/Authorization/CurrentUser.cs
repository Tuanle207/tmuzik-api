using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Tmuzik.Common.Consts;
using Tmuzik.Common.DependencyInjections;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Interfaces;

namespace Tmuzik.Infrastructure.Authorization
{
    public class CurrentUser : ICurrentUser, IScopedDependency<ICurrentUser> 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        private AuthUser _authUser => _httpContextAccessor.HttpContext?
            .Items[AuthConst.HttpContextUserItemName] as AuthUser;


        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated => _authUser is not null;
        public Guid? Id => _authUser is null ? null : _authUser.Id;
        public Guid? ProfileId => _authUser is null ? null : _authUser.Profile.Id;
        public string Email => _authUser is null ? null : _authUser.Email;
        public bool? Verified => _authUser is null ? null : _authUser.Verified;
        public DateTime? CreationTime => _authUser is null ? null : _authUser.CreationTime;
        public AuthUserProfile Profile => _authUser is null ? null : _authUser.Profile;
    }
}