using Assessment.Domain.Aggregates;
using BuildingBlocks.Application;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Infrastructure.Persistence
{
    public sealed class AssessmentDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Grade> Grades => Set<Grade>();

        public AssessmentDbContext(DbContextOptions<AssessmentDbContext> options)
            : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AssessmentDbContext).Assembly);
        }
    }
}
