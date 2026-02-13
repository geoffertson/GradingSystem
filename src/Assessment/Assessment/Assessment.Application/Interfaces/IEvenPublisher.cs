using BuildingBlocks.Domain;

namespace Assessment.Application.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishAsync(
            IDomainEvent domainEvent,
            CancellationToken cancellationToken);
    }
}
