using Microsoft.EntityFrameworkCore;
using QuizPlatform.Core.Entities;
using QuizPlatform.Core.Repositories;
using QuizPlatform.Infrastructure.Context;

namespace QuizPlatform.Infrastructure.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizPlatformDbContext _context;
        private readonly DbSet<Quiz> _quizzes;
        public QuizRepository(QuizPlatformDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _quizzes = _context.Set<Quiz>();    
        }

        public async Task AddAsync(Quiz quiz, CancellationToken cancellationToken)
        {
            await _quizzes.AddAsync(quiz, cancellationToken);
        }

        public async Task DeleteAsync(Guid id)
        { 
            var quiz = await _quizzes.FindAsync(id);

            _quizzes.Remove(quiz);
        }

        public async Task<List<Quiz>> GetByAuthorIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _quizzes
                .AsNoTracking()
                .Where(q => q.UserId == userId)
                .OrderBy(q=>q.Title)
                .ToListAsync(cancellationToken); 
        }

        public async Task<Quiz> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _quizzes
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id == id, cancellationToken);
        }

        public void Update(Quiz quiz)
        {
            _quizzes.Update(quiz);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
