using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizPlatform.Core.Entities;

namespace QuizPlatform.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u=>u.Id);

            builder.Property(u=>u.UserName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(u=>u.Email);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.PasswordHash);

            builder.ToTable("Users");
        }
         
    }
}
