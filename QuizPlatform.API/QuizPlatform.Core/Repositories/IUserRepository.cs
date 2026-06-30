using QuizPlatform.Core.Entities;

namespace QuizPlatform.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
        Task<User?> GetUserById(Guid userId, CancellationToken cancellationToken);  
        Task AddAsync(User user, CancellationToken cancellationToken);  
        void Update(User user);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
