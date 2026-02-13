using Assessment.Application.Interfaces;
using Assessment.Domain.Aggregates;
using Assessment.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Infrastructure.Repositories
{
    public sealed class GradeRepository : IGradeRepository
    {
        private readonly AssessmentDbContext _context;

        public GradeRepository(AssessmentDbContext context)
        {
            _context = context;
        }

        public async Task<Grade?> GetByIdAsync(
            Guid gradeId,
            CancellationToken cancellationToken)
        {
            return await _context.Grades
                .FirstOrDefaultAsync(g => g.GradeId == gradeId, cancellationToken);
        }

        public async Task AddAsync(
            Grade grade,
            CancellationToken cancellationToken)
        {
            await _context.Grades.AddAsync(grade, cancellationToken);
        }
    }
}
