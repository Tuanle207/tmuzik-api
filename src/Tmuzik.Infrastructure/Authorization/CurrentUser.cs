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
        private readonly ILogger<CurrentUser> _logger;


        private AuthUser _authUser => _httpContextAccessor.HttpContext?
            .Items[AuthConst.HttpContextUserItemName] as AuthUser;


        public CurrentUser(IHttpContextAccessor httpContextAccessor, ILogger<CurrentUser> logger)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated => _authUser is not null;
        public Guid? Id => _authUser is null ? null : _authUser.Id;
        public string Email => _authUser is null ? null : _authUser.Email;
        public string FullName => _authUser is null ? null : _authUser.FullName;
        public string Test
        {
            get
            {
                return _authUser is null ? null : _authUser.Email;
            }
        }
    }
}