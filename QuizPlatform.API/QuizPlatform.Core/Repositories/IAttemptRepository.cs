using QuizPlatform.Core.Entities;

namespace QuizPlatform.Core.Repositories
{
    public interface IAttemptRepository
    {
        Task<QuizAttempt> GetByIdAsync(Guid quizAttemptId, CancellationToken cancellationToken);
        Task<List<QuizAttempt>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<List<QuizAttempt>> GetByQuizIdAsync(Guid quizId, CancellationToken cancellationToken);
        Task AddAsync(QuizAttempt attempt, CancellationToken cancellationToken);
        Task UpdateAsync(QuizAttempt attempt);

    }
}
