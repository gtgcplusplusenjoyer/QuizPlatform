using Microsoft.EntityFrameworkCore;
using QuizPlatform.Core.Entities;
using QuizPlatform.Core.Repositories;
using QuizPlatform.Infrastructure.Context;

namespace QuizPlatform.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbSet<User> _users;
        private QuizPlatformDbContext _context;
        public UserRepository(QuizPlatformDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _users = _context.Set<User>();
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _users.AddAsync(user, cancellationToken);
        }

        public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            return await _users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<User?> GetUserById(Guid userId, CancellationToken cancellationToken)
        {
            return await _users.FirstOrDefaultAsync(u=>u.Id== userId, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Update(User user)
        {
            _users.Update(user);
        }
    }
}
