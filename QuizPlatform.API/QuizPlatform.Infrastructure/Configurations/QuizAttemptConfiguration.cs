using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizPlatform.Core.Entities;

namespace QuizPlatform.Infrastructure.Configurations
{
    public class QuizAttemptConfiguration : IEntityTypeConfiguration<QuizAttempt>
    {
        public void Configure(EntityTypeBuilder<QuizAttempt> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.UserId)
                .IsRequired();

            builder.Property(a => a.QuizId)
                .IsRequired();

            builder.Property(a => a.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(a => a.StartedAt)
                .IsRequired()
                .HasColumnType("timestamp");

            builder.Property(a => a.FinishedAt)
                .HasColumnType("timestamp");

            builder.Property(a => a.Score)
                .HasColumnType("int");

            builder.Property(a => a.MaxScore)
                .HasColumnType("int");

            builder.ToTable("QuizAttempts");
        }
    }
}
