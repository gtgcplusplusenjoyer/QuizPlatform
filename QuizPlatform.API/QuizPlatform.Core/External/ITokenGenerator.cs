using QuizPlatform.Core.Entities;
using QuizPlatform.Core.Tokens;

namespace QuizPlatform.Core.External
{
    public interface ITokenGenerator
    {
        TokenPair GenerateTokenPair(User user);
    }
}
