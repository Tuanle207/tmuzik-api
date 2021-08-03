using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Tmuzik.Infrastructure.Consts;
using Tmuzik.Infrastructure.DependencyInjections;
using Tmuzik.Infrastructure.Models;

namespace Tmuzik.Infrastructure.Services.Authorization
{
    public class CurrentUser : ICurrentUser, IScopedDependency<ICurrentUser> 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<CurrentUser> _logger;

        private AuthDto _authUser => _httpContextAccessor.HttpContext?
            .Items[AuthConst.HttpContextAuthItemName] as AuthDto;


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