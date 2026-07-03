using Microsoft.Extensions.Options;
using QuizPlatform.Application.Dto.User;
using QuizPlatform.Application.Interfaces;
using QuizPlatform.Core.Entities;
using QuizPlatform.Core.External;
using QuizPlatform.Core.Models;
using QuizPlatform.Core.Repositories;
using QuizPlatform.Core.Tokens;
using QuizPlatform.Infrastructure.Settings;

namespace QuizPlatform.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly AuthSettings _settings;
        public AuthService(
            IRefreshTokenRepository refreshTokenRepository,
            IUserRepository userRepository,
            ITokenGenerator tokenGenerator,
            IPasswordHasher passwordHasher,
            IOptions<AuthSettings> options)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            _passwordHasher = passwordHasher;
            _settings = options.Value;
        }
        public async Task<AuthResult> LoginAsync(LoginUserDto loginUserDto, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginUserDto.Email, cancellationToken);

            if (user == null)
            {
                return AuthResult.Fail("User with this email does not exist");
            }

            if(!_passwordHasher.VerifyPassword(loginUserDto.Password, user.PasswordHash))
            {
                return AuthResult.Fail("Wrong password");
            }

            var tokenPair = _tokenGenerator.GenerateTokenPair(user);

            var refreshToken = CreateRefreshToken(tokenPair, user.Id);

            await _refreshTokenRepository.CreateAsync(refreshToken, cancellationToken);
            await _refreshTokenRepository.SaveChangesAsync(cancellationToken);

            return AuthResult.Success(tokenPair, user.Id);
        }

        public async Task<AuthResult> LogoutAsync(Guid userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);

            if (user == null)
            {
                return AuthResult.Fail("User with this Id is not found");
            }

            await _refreshTokenRepository.RevokeAllTokensByUserIdAsync(user.Id, cancellationToken);
            await _refreshTokenRepository.SaveChangesAsync(cancellationToken);

            return AuthResult.Success(user.Id);
        }

        public async Task<AuthResult> RefreshToken(string refreshToken, CancellationToken cancellationToken)
        {
            var storedToken = await _refreshTokenRepository.GetByTokenAsync(refreshToken, cancellationToken);

            if (storedToken == null)
            {
                return AuthResult.Fail("Token is not found");
            }

            if (storedToken.IsRevoked)
            {
                return AuthResult.Fail("Token is revoked");
            }

            if (storedToken.ExpiresAt < DateTime.UtcNow)
            {
                return AuthResult.Fail("Token has expired");
            }

            var user = await _userRepository.GetUserByIdAsync(storedToken.UserId, cancellationToken);

            if (user == null)
            {
                return AuthResult.Fail("User is not found");
            }

            await _refreshTokenRepository.RevokeAsync(storedToken.Id, cancellationToken);

            var tokenPair = _tokenGenerator.GenerateTokenPair(user);

            var newRefreshToken = CreateRefreshToken(tokenPair, user.Id);

            await _refreshTokenRepository.CreateAsync(newRefreshToken, cancellationToken);
            await _refreshTokenRepository.SaveChangesAsync(cancellationToken);

            return AuthResult.Success(tokenPair, user.Id);
        }

        public async Task<AuthResult> RegisterAsync(RegisterUserDto registerUserDto, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(registerUserDto.Email,cancellationToken);

            if (existingUser != null)
            {
                return AuthResult.Fail("User with this email already exist");
            }

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Email = registerUserDto.Email,
                PasswordHash = _passwordHasher.HashPassword(registerUserDto.Password),
                UserName = registerUserDto.UserName,
            };

            await _userRepository.AddAsync(newUser, cancellationToken);
            await _userRepository.SaveChangesAsync(cancellationToken);

            var tokenPair = _tokenGenerator.GenerateTokenPair(newUser);

            var refreshToken = CreateRefreshToken(tokenPair, newUser.Id);

            await _refreshTokenRepository.CreateAsync(refreshToken, cancellationToken);
            await _refreshTokenRepository.SaveChangesAsync(cancellationToken);

            return AuthResult.Success(tokenPair, newUser.Id);

        }

        private RefreshToken CreateRefreshToken(TokenPair tokenPair, Guid userId)
        {
            return new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = tokenPair.RefreshToken,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(_settings.RefreshTokenExpirationDays),
                IsRevoked = false,
                UserId = userId,
            };
        }
    }
}
