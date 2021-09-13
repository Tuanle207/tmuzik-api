using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Interfaces.Services;

namespace Tmuzik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistsController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet("uploaded")]
        public async Task<IActionResult> GetUserPlaylists(CancellationToken cancellationToken)
        {
            var result = await _playlistService.GetUserPlaylistsAsync(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaylistDetail([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _playlistService.GetPlaylistDetailAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreatePlaylist([FromForm] CreatePlaylistRequest input, CancellationToken cancellationToken)
        {
            var result = await _playlistService.CreatePlaylistAsync(input, cancellationToken);
            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdatePlaylist([FromRoute] Guid id, [FromForm] UpdatePlaylistRequest input, CancellationToken cancellationToken)
        {
            input.Id = id;
            var result = await _playlistService.UpdatePlaylistAsync(input, cancellationToken);
            return Ok(result);
        } 

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePlaylist([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _playlistService.RemovePlaylistAsync(id, cancellationToken);
            return NoContent();
        } 

        [HttpPost("{id}/add-items")]
        public async Task<IActionResult> AddPlaylistItem([FromRoute] Guid id, [FromBody] AddPlaylistItemRequest input, CancellationToken cancellationToken)
        {
            var result = await _playlistService.AddPlaylistItemAsync(input, id, cancellationToken);
            return Ok(result);
        }

        [HttpPost("{id}/remove-items")]
        public async Task<IActionResult> RemovePlaylistItem([FromRoute] Guid id, [FromBody] RemovePlaylistItemRequest input, CancellationToken cancellationToken)
        {
            await _playlistService.RemovePlaylistItemAsync(input, id, cancellationToken);
            return Ok();
        }
    }
}