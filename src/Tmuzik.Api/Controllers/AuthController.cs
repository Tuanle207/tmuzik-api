using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Interfaces.Services;

namespace Tmuzik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IIdentityService identityService, ILogger<AuthController> logger)
        {
            _identityService = identityService;
            _logger = logger;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest input, CancellationToken cancellationToken)
        {
            var result = await _identityService.SignupAsync(input, cancellationToken);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest input, CancellationToken cancellationToken)
        {
            var result = await _identityService.LoginAsync(input, cancellationToken);
            return Ok(result);
        }

        [HttpPost("loginWithFacebook")]
        public async Task<IActionResult> LoginWithFacebook([FromBody] LoginWithFacebookRequest input, CancellationToken cancellationToken)
        {
            var result = await _identityService.LoginWithFacebookAsync(input, cancellationToken);
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshLoginSession([FromBody] RefreshLoginRequest input, CancellationToken cancellationToken)
        {
            var result = await _identityService.RefreshLoginSessionAsync(input, cancellationToken);
            return Ok(result); 
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> RevokeLoginSession([FromBody] RevokeLoginRequest input, CancellationToken cancellationToken)
        {
            await _identityService.RevokeLoginSessionAsync(input, cancellationToken);
            return NoContent(); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserProfile([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _identityService.GetUserProfileAsync(id, cancellationToken);
            return Ok(result);
        }
    }
}