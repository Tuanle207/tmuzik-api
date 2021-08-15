using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tmuzik.Common.Models;

namespace Tmuzik.Api.Filters
{
    public class ResultFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            
            if (context.Result is OkObjectResult objectResult)
            {
                SuccessResponse response;

                if (objectResult.Value is null)
                {
                    response = new SuccessResponse
                    {
                        Status = StatusCodes.Status204NoContent,
                        Data = objectResult.Value
                    };
                }
                else
                {
                    response = new SuccessResponse
                    {
                        Status = StatusCodes.Status200OK,
                        Data = objectResult.Value
                    };
                }
                context.Result = new OkObjectResult(response);
            }

            await next();
        }
    }
}