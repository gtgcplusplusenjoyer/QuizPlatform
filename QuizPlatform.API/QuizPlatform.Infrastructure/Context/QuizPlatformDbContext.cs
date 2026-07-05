using Microsoft.EntityFrameworkCore;
using QuizPlatform.Core.Entities;
using QuizPlatform.Core.Tokens;
using QuizPlatform.Infrastructure.Configurations;

namespace QuizPlatform.Infrastructure.Context
{
    public class QuizPlatformDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }
        public QuizPlatformDbContext(DbContextOptions<QuizPlatformDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
            modelBuilder.ApplyConfiguration(new QuizAttemptConfiguration());
        }

    }
}
