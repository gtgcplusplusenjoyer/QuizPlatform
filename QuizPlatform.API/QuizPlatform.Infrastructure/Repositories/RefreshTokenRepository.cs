using Microsoft.EntityFrameworkCore;
using QuizPlatform.Core.Repositories;
using QuizPlatform.Core.Tokens;
using QuizPlatform.Infrastructure.Context;

namespace QuizPlatform.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private DbSet<RefreshToken> _tokens;
        private QuizPlatformDbContext _context;
        public RefreshTokenRepository(QuizPlatformDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tokens = _context.Set<RefreshToken>();
        }

        public async Task CreateAsync(RefreshToken refreshToken, CancellationToken cancellationToken)
        {
            await _tokens.AddAsync(refreshToken, cancellationToken);
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken)
        {
            return await _tokens.FirstOrDefaultAsync(t => t.Token == token, cancellationToken);
        }

        public async Task RevokeAllTokensByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var tokens = await _tokens.
                Where(t => t.UserId == userId && !t.IsRevoked).
                ToListAsync(cancellationToken);

            foreach (var token in tokens)
            {
                token.IsRevoked = true;
            }

            if (tokens.Any())
            {
                await _context.SaveChangesAsync(cancellationToken);
            }

        }

        public async Task RevokeAsync(Guid TokenId, CancellationToken cancellationToken)
        {
            var token = await _tokens.FindAsync(TokenId, cancellationToken);

            if (token != null)
            {
                token.IsRevoked = true;
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
