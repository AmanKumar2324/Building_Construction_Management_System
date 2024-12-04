using Microsoft.AspNetCore.Mvc;
using Building_Construction_Management_System.Helpers;
using Building_Construction_Management_System.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Building_Construction_Management_System.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenHelper _jwtTokenHelper;

        public AuthController(IUserRepository userRepository, JwtTokenHelper jwtTokenHelper)
        {
            _userRepository = userRepository;
            _jwtTokenHelper = jwtTokenHelper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            // Validate credentials
            var user = await _userRepository.AuthenticateUserAsync(loginRequest.RoleUserId, loginRequest.Password);

            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid credentials." });
            }

            // Generate JWT
            var token = _jwtTokenHelper.GenerateToken(user.RoleUserId, user.Role);

            return Ok(new
            {
                User = new
                {
                    user.RoleUserId,
                    user.Username,
                    user.Role
                },
                Token = token
            });
        }
    }

    public class LoginRequest
    {
        public string RoleUserId { get; set; }
        public string Password { get; set; }
    }
}
