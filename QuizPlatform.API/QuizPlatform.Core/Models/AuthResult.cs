using QuizPlatform.Core.Tokens;

namespace QuizPlatform.Core.Models
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; } = string.Empty;
        public TokenPair? TokenPair { get; set; }
        public Guid? UserId { get; set; }

        public static AuthResult Success(TokenPair tokenPair, Guid UserId)
        {
            return new AuthResult
            {
                IsSuccess = true,
                TokenPair = tokenPair,
                UserId = UserId
            };
        }

        public static AuthResult Success(Guid UserId)
        {
            return new AuthResult
            {
                IsSuccess = true,
                UserId = UserId
            };
        }

        public static AuthResult Fail(string message)
        {
            return new AuthResult
            {
                IsSuccess = false,
                ErrorMessage = message
            };
        }

    }
}
