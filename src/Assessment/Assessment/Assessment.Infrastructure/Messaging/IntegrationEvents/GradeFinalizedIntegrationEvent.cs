using BuildingBlocks.Messaging;

namespace Assessment.Infrastructure.Messaging.IntegrationEvents
{
    public sealed record GradeFinalizedIntegrationEvent(
    Guid GradeId,
    Guid StudentId,
    Guid SubjectId
    ) : IntegrationEvent
    {
        public override string EventType => "Assessment.GradeFinalized";
    }
}
