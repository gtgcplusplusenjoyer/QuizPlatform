using QuizPlatform.Core.Entities;

namespace QuizPlatform.Core.Repositories
{
    public interface IQuizRepository
    {
        Task<Quiz> GetByIdAsync(Guid id,CancellationToken cancellationToken);
        Task<List<Quiz>> GetByAuthorIdAsync(Guid userId,CancellationToken cancellationToken);
        Task AddAsync(Quiz quiz,CancellationToken cancellationToken);
        void Update(Quiz quiz);
        Task DeleteAsync(Guid id); 
        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task<Quiz?> GetQuizWithQuestionsAndAnswersAsync(Guid id, CancellationToken cancellationToken);
    }
}
