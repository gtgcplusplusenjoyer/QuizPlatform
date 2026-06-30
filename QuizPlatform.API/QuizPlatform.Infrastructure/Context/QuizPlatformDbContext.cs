using Microsoft.EntityFrameworkCore;
using QuizPlatform.Core.Entities;
using QuizPlatform.Infrastructure.Configurations;

namespace QuizPlatform.Infrastructure.Context
{
    public class QuizPlatformDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public QuizPlatformDbContext(DbContextOptions<QuizPlatformDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
