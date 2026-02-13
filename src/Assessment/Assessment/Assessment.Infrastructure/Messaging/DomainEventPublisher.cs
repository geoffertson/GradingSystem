using Assessment.Application.Interfaces;
using Assessment.Domain.DomainEvents;
using Assessment.Infrastructure.Messaging.IntegrationEvents;
using BuildingBlocks.Domain;

namespace Assessment.Infrastructure.Messaging
{
    public sealed class DomainEventPublisher : IEventPublisher
    {
        // Kafka producer will be injected later
        public DomainEventPublisher()
        {
        }

        public Task PublishAsync(
            IDomainEvent domainEvent,
            CancellationToken cancellationToken)
        {
            if (domainEvent is GradeFinalizedDomainEvent e)
            {
                var integrationEvent =
                    new GradeFinalizedIntegrationEvent(
                        e.GradeId,
                        e.StudentId,
                        e.SubjectId);

                // TODO: publish to Kafka
            }

            return Task.CompletedTask;
        }
    }
}
