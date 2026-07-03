using QuizPlatform.Application.Dto.User;
using QuizPlatform.Core.Models;

namespace QuizPlatform.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(RegisterUserDto registerUserDto, CancellationToken cancellationToken);
        Task<AuthResult> LoginAsync(LoginUserDto loginUserDto, CancellationToken cancellationToken);
        Task<AuthResult> LogoutAsync(Guid userId, CancellationToken cancellationToken);
        Task<AuthResult> RefreshToken(string refreshToken, CancellationToken cancellationToken);
    }
}
