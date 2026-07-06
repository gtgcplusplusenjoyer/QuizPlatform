using Microsoft.EntityFrameworkCore;
using QuizPlatform.Core.Entities;
using QuizPlatform.Core.Repositories;
using QuizPlatform.Infrastructure.Context;

namespace QuizPlatform.Infrastructure.Repositories
{
    public class AttemptRepository : IAttemptRepository
    {
        private readonly QuizPlatformDbContext _context;
        private readonly DbSet<QuizAttempt> _attempts;
        public AttemptRepository(QuizPlatformDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _attempts = _context.Set<QuizAttempt>();
        }

        public async Task AddAsync(QuizAttempt attempt, CancellationToken cancellationToken)
        {
            await _attempts.AddAsync(attempt, cancellationToken);
        }

        public async Task<QuizAttempt> GetByIdAsync(Guid quizAttemptId, CancellationToken cancellationToken)
        {
            return await _attempts
                .AsNoTracking()
                .FirstOrDefaultAsync(a=>a.Id==quizAttemptId);
        }

        public async Task<List<QuizAttempt>> GetByQuizIdAsync(Guid quizId, CancellationToken cancellationToken)
        {
            return await _attempts
                .AsNoTracking()
                .Where(a => a.QuizId == quizId)
                .OrderBy(a=>a.User)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<QuizAttempt>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _attempts
                .AsNoTracking()
                .Where(a => a.UserId == userId)
                .OrderBy(a=>a.User)
                .ToListAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void UpdateAsync(QuizAttempt attempt)
        {
            _attempts.Update(attempt);
        }
    }
}
