using QuizPlatform.Core.Tokens;

namespace QuizPlatform.Core.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken);
        Task CreateAsync(RefreshToken refreshToken, CancellationToken cancellationToken);
        Task RevokeAsync(Guid TokenId, CancellationToken cancellationToken);
        Task RevokeAllTokensByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
