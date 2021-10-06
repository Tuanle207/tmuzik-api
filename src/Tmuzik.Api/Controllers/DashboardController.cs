using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Interfaces.Services;

namespace Tmuzik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetSearchResults([FromQuery] GetSearchResultsRequest input, CancellationToken cancellationToken)
        {
            var result = await _dashboardService.GetSearchResultsAsync(input, cancellationToken);
            return Ok(result);
        }
    }
}