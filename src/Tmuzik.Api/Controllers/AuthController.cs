using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tmuzik.Application.Dto.Users;
using Tmuzik.Application.Services;

namespace Tmuzik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignupRequest input)
        {
            var result = await _userService.Signup(input);
            return Ok(result);
        }
    }
}