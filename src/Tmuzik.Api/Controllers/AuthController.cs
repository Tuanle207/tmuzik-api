using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tmuzik.Application.Dto.Requests;
using Tmuzik.Application.Services;

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
            var result = await _userService.Signup(input);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest input)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("invalid");
                _logger.LogInformation(JsonSerializer.Serialize(ModelState.Values));
            }
            var result = await _userService.Login(input);
            return Ok(result);
        }
    }
}