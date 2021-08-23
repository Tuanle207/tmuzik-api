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
        public async Task<IActionResult> Signup(SignupRequest input)
        {
            var result = await _identityService.SignupAsync(input);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest input)
        {
            var result = await _identityService.LoginAsync(input);
            return Ok(result);
        }

        [HttpPost("loginWithFacebook")]
        public async Task<IActionResult> LoginWithFacebook(LoginWithFacebookRequest input)
        {
            var result = await _identityService.LoginWithFacebookAsync(input);
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshLoginSession(RefreshLoginRequest input)
        {
            var result = await _identityService.RefreshLoginSessionAsync(input);
            return Ok(result); 
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> RevokeLoginSession(RevokeLoginRequest input)
        {
            await _identityService.RevokeLoginSessionAsync(input);
            return NoContent(); 
        }
    }
}