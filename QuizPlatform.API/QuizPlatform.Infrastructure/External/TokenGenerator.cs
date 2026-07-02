using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QuizPlatform.Core.Entities;
using QuizPlatform.Core.External;
using QuizPlatform.Core.Tokens;
using QuizPlatform.Infrastructure.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace QuizPlatform.Infrastructure.External
{
    public class TokenGenerator : ITokenGenerator
    {
        private AuthSettings _settings;
        public TokenGenerator(IOptions<AuthSettings> settings)
        {
            _settings = settings.Value;
        }

        public TokenPair GenerateTokenPair(User user)
        {
            var accessToken = GenerateAccessToken(user);
            var refreshToken = GenerateRefreshToken();

            TokenPair tokenPair = new TokenPair
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };

            return tokenPair;
        }

        private string GenerateRefreshToken()
        {
            var randomBytes = new byte[32];
            using var rng = RandomNumberGenerator.Create();

            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        private string GenerateAccessToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                    issuer: _settings.Issuer,
                    audience: _settings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_settings.AccessTokenExpirationMinutes),
                    signingCredentials: credentials
            );
            
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
