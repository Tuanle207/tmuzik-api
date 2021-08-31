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
            var result = await _playlistService.GetUserPlaylists(cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserPlaylistDetail([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _playlistService.GetUserPlaylistDetail(id, cancellationToken);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePlaylist([FromForm] CreatePlaylistRequest input, CancellationToken cancellationToken)
        {
            var result = await _playlistService.CreatePlaylist(input, cancellationToken);
            return Ok(result);
        } 

        [HttpPost("{id")]
        public async Task<IActionResult> UpdatePlaylist([FromForm] UpdatePlaylistRequest input, CancellationToken cancellationToken)
        {
            var result = await _playlistService.UpdatePlaylist(input, cancellationToken);
            return Ok(result);
        } 

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePlaylist([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _playlistService.RemovePlaylist(id, cancellationToken);
            return NoContent();
        } 

        [HttpPost("{id}/items")]
        public async Task<IActionResult> AddPlaylistItem([FromBody] AddPlaylistItemRequest input, CancellationToken cancellationToken)
        {
            await _playlistService.AddPlaylistItem(input, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}/items")]
        public async Task<IActionResult> RemovePlaylistItem([FromBody] RemovePlaylistItemRequest input, CancellationToken cancellationToken)
        {
            await _playlistService.RemovePlaylistItem(input, cancellationToken);
            return Ok();
        } 
    }
}