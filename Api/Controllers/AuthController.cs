using Api.DTOs;
using Api.Models;
using Api.Repositories.UserRepository;
using Api.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public AuthController(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDto request)
        {
            if (!_authService.IsValidUsername(request.Username))
            {
                return BadRequest("Username too short");
            }
            if (!_authService.IsValidPassword(request.Password))
            {
                return BadRequest("Password too short");
            }
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user is not null)
            {
                return Conflict("Username is taken");
            }

            _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            await _userRepository.AddUserAsync(newUser);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserDto request)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user is null || !_authService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("User not found or wrong password.");
            }

            string token = _authService.CreateToken(user);
            return Ok(token);
        }
    }
}
