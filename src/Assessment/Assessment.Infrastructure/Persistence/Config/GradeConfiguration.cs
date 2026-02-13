using Assessment.Domain.Aggregates;
using Assessment.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment.Infrastructure.Persistence.Config
{
    public sealed class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.GradeId);

            builder.Property(g => g.StudentId).IsRequired();
            builder.Property(g => g.SubjectId).IsRequired();

            builder.OwnsOne<Score>(
                g => g.Score,
                score =>
                {
                    score.Property(s => s.Value)
                         .HasColumnName("Score")
                         .IsRequired();
                });

            builder.Property(g => g.IsFinal).IsRequired();
        }
    }
}
