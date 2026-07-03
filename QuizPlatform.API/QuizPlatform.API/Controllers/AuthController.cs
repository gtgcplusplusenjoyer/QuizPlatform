using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizPlatform.API.Extensions;
using QuizPlatform.Application.Dto.User;
using QuizPlatform.Application.Interfaces;

namespace QuizPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto,
            CancellationToken cancellationToken)
        {
            var result = await _service.RegisterAsync(registerUserDto, cancellationToken); 
            if(!result.IsSuccess)
            {
                return BadRequest(new { message = result.ErrorMessage });
            }

            return Ok(new
            {
                accessToken = result.TokenPair!.AccessToken,
                refreshToken = result.TokenPair!.RefreshToken,
                userId = result.UserId
            });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(CancellationToken cancellationToken)
        {
            var userIdClaim = User.GetUserId();

            if(userIdClaim == null)
            {
                return BadRequest(new { message = "Invalid user identifier in token" });
            }

            var result = await _service.LogoutAsync(userIdClaim.Value, cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(new {message = result.ErrorMessage});
            }

            return Ok(new { message = "User logged out successfully"});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto,
            CancellationToken cancellationToken)
        {
            var result = await _service.LoginAsync(loginUserDto, cancellationToken);

            if (!result.IsSuccess)
            {
                return Unauthorized(new { message = result.ErrorMessage });
            }

            return Ok(new
            {
                accessToken = result.TokenPair!.AccessToken,
                refreshToken = result.TokenPair!.RefreshToken,
                userId = result.UserId
            });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokerRequestDto refreshTokerRequestDto,
            CancellationToken cancellationToken)
        {
            var result = await _service.RefreshToken(refreshTokerRequestDto.RefreshToken, cancellationToken);

            if (!result.IsSuccess)
            {
                return Unauthorized(new { message = result.ErrorMessage });
            }

            return Ok(new
            {
                accessToken = result.TokenPair!.AccessToken,
                refreshToken = result.TokenPair!.RefreshToken,
                userId = result.UserId
            });
        }
    }
}
