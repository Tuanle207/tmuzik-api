using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Interfaces.Services;

namespace Tmuzik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpPost("")]
        public async Task<IActionResult> ClaimArtist([FromForm] ClaimArtistRequest input, CancellationToken cancellationToken)
        {
            var result = await _artistService.ClaimArtistAsync(input, cancellationToken);
            return Ok(result);
        }
    }
}