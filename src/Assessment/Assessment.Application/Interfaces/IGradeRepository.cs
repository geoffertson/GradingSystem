using Assessment.Domain.Aggregates;

namespace Assessment.Application.Interfaces
{
    public interface IGradeRepository
    {
        Task<Grade?> GetByIdAsync(Guid gradeId, CancellationToken cancellationToken);
        Task AddAsync(Grade grade, CancellationToken cancellationToken);
    }
}
