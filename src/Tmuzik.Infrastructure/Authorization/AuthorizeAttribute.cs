using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tmuzik.Common.Consts;
using Tmuzik.Core.Contract.Models;

namespace Tmuzik.Infrastructure.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (AuthUser)context.HttpContext.Items[AuthConst.HttpContextUserItemName];
            if (user == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) 
                { 
                    StatusCode = StatusCodes.Status401Unauthorized 
                };
            }
        }
    }
}