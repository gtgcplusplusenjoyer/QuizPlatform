using QuizPlatform.Core.Entities;

namespace QuizPlatform.Core.Repositories
{
    public interface IQuizRepository
    {
        Task<Quiz> GetByIdAsync(Guid id,CancellationToken cancellationToken);
        Task<List<Quiz>> GetByAuthorIdAsync(Guid userId,CancellationToken cancellationToken);
        Task AddAsync(Quiz quiz,CancellationToken cancellationToken);
        Task UpdateAsync(Quiz quiz);
        Task DeleteAsync(Guid id);
    }
}
