using QuizPlatform.Core.Entities;

namespace QuizPlatform.Application.Interfaces
{
    public interface IAttemptService
    {
        Task CreateAttemptAsync(Guid quizId, Guid userId, CancellationToken cancellationToken);
        Task<QuizAttempt> SaveAnswersAsync(Guid attemptId, Dictionary<Guid, string> answers, CancellationToken cancellationToken);
        Task<QuizAttempt> FinishAttemptAsync(Guid attemptId, CancellationToken cancellationToken);  
        Task<QuizAttempt> GetAttemptResultAsync(Guid attemptId, CancellationToken cancellationToken);
        Task<List<QuizAttempt>> GetUserAttemptsByIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<List<QuizAttempt>> GetQuizAttemptsByIdAsync(Guid quizId,  CancellationToken cancellationToken);
    }
}
