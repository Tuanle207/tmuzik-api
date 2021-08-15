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
        private readonly IUserService _userService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserService userService, ILogger<AuthController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignupRequest input)
        {
            var result = await _userService.SignupAsync(input);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest input)
        {
            var result = await _userService.LoginAsync(input);
            return Ok(result);
        }

        [HttpPost("loginWithFacebook")]
        public async Task<IActionResult> LoginWithFacebook(LoginWithFacebookRequest input)
        {
            var result = await _userService.LoginWithFacebookAsync(input);
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshLoginSession(RefreshLoginRequest input)
        {
            var result = await _userService.RefreshLoginSessionAsync(input);
            return Ok(result); 
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> RevokeLoginSession(RefreshLoginRequest input)
        {
            var result = await _userService.RefreshLoginSessionAsync(input);
            return Ok(result); 
        }
    }
}