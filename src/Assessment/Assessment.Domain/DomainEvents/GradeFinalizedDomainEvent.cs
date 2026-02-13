using BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Domain.DomainEvents
{
    public sealed record GradeFinalizedDomainEvent(Guid GradeId, Guid StudentId,Guid SubjectId) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}
