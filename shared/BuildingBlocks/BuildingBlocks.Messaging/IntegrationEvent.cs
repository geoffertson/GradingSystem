namespace BuildingBlocks.Messaging
{
    public abstract record IntegrationEvent
    {
        public Guid EventId { get; init; } = Guid.NewGuid();
        public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
        public abstract string EventType { get; }
        public virtual int Version => 1;
    }
}
