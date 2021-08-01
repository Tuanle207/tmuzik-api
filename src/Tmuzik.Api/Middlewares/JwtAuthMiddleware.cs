using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Tmuzik.Application.Services;
using Tmuzik.Infrastructure.Consts;
using Tmuzik.Infrastructure.Services.Authorization;

namespace Tmuzik.Api.Middlewares
{
    public class JwtAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, AuthHelper authHelper)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                await AttachUserToContext(context, userService, authHelper, token); 
            }

            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, IUserService userService,
            AuthHelper authHelper, string token)
        {
            var userId = authHelper.ValidateToken(token);

            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items[AuthConst.HttpContextAuthItemName] = await userService.GetUserById(userId.Value);
            }
            else
            {
                context.Items[AuthConst.HttpContextAuthItemName] = null;
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