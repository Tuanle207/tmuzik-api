using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Tmuzik.Common.Consts;
using Tmuzik.Core.Interfaces.Helpers;
using Tmuzik.Core.Interfaces.Services;

namespace Tmuzik.Api.Middlewares
{
    public class JwtAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IIdentityService identityService, IAuthHelper authHelper)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                await AttachUserToContext(context, identityService, authHelper, token); 
            }

            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, IIdentityService identityService,
            IAuthHelper authHelper, string token)
        {
            var userId = authHelper.ValidateToken(token);

            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items[AuthConst.HttpContextUserItemName] = await identityService.GetUserForApplicationAuthAsync(userId.Value);
            }
            else
            {
                context.Items[AuthConst.HttpContextUserItemName] = null;
            }
        }
    }

    public static class JwtAuthMiddlewareExtesions
    {
        public static IApplicationBuilder UseJwtAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtAuthMiddleware>();
        }
    }
}