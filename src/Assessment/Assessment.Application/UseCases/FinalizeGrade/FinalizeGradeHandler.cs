using Assessment.Application.Interfaces;
using BuildingBlocks.Application;

namespace Assessment.Application.UseCases.FinalizeGrade
{
    public sealed class FinalizeGradeHandler
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventPublisher _eventPublisher;

        public FinalizeGradeHandler(
            IGradeRepository gradeRepository,
            IUnitOfWork unitOfWork,
            IEventPublisher eventPublisher)
        {
            _gradeRepository = gradeRepository;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
        }

        public async Task<FinalizeGradeResult> Handle(
            FinalizeGradeCommand command,
            CancellationToken cancellationToken)
        {
            var grade = await _gradeRepository
                .GetByIdAsync(command.GradeId, cancellationToken)
                ?? throw new InvalidOperationException("Grade not found.");

            grade.FinalizeGrade();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in grade.DomainEvents)
            {
                await _eventPublisher.PublishAsync(domainEvent, cancellationToken);
            }

            grade.ClearDomainEvents();

            return new FinalizeGradeResult(grade.GradeId);
        }
    }
}
