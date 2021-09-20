using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Interfaces.Services;

namespace Tmuzik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class AudiosController : ControllerBase
    {
        private readonly IAudioService _audioService;

        public AudiosController(IAudioService audioService)
        {
            _audioService = audioService;
        }

        [HttpGet("uploaded")]
        public async Task<IActionResult> GetUserUploadAudio([FromQuery] GetUserUploadAudioRequest input, CancellationToken cancellationToken)
        {
            var result = await _audioService.GetUserUploadAudioAsync(input, cancellationToken);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> UploadAudio([FromForm] UploadAudioRequest input, CancellationToken cancellationToken)
        {
            // var files = Request.Files
            var result = await _audioService.AddAudioAsync(input, cancellationToken);
            return Ok(result);
        }

    }
}