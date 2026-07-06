using QuizPlatform.Core.Entities;

namespace QuizPlatform.Application.Interfaces
{
    public interface IQuizService
    {
        Task<Quiz> GetQuizByIdAsync(Guid quizId,CancellationToken cancellationToken);
        Task<List<Quiz>> GetQuizzesByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken);
        Task CreateQuizAsync(Quiz quiz,CancellationToken cancellationToken);
        Task DeleteQuizAsync(Guid quizId, CancellationToken cancellationToken);   
        Task UpdateQuizAsync(Guid quizId, CancellationToken cancellationToken);
        Task PublishQuizAsync(Guid quizId, CancellationToken cancellationToken);
    }
}
