using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizPlatform.Core.Entities;

namespace QuizPlatform.Infrastructure.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.UserId)
                .IsRequired();

            builder.Property(q => q.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(q => q.Description)
                .HasMaxLength(1000);

            builder.Property(q=>q.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp");

            builder.Property(q=>q.UpdatedAt)
                .HasColumnType("timestamp");

            builder.Property(q=>q.PublishedAt)
                .HasColumnType("timestamp");

            builder.ToTable("Quiz");
        }
    }
}
