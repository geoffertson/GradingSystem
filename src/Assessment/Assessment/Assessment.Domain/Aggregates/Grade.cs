using Assessment.Domain.DomainEvents;
using Assessment.Domain.Exceptions;
using Assessment.Domain.ValueObjects;
using BuildingBlocks.Domain;

namespace Assessment.Domain.Aggregates
{
    public sealed class Grade : AggregateRoot
    {
        public Guid GradeId { get; private set; }
        public Guid StudentId { get; private set; }
        public Guid SubjectId { get; private set; }

        public Score Score { get; private set; } = null!;
        public bool IsFinal { get; private set; }

        private Grade() { } // For ORM

        private Grade(
            Guid gradeId,
            Guid studentId,
            Guid subjectId,
            Score score)
        {
            GradeId = gradeId;
            StudentId = studentId;
            SubjectId = subjectId;
            Score = score;
            IsFinal = false;
        }

        public static Grade Assign(
            Guid gradeId,
            Guid studentId,
            Guid subjectId,
            Score score)
        {
            return new Grade(gradeId, studentId, subjectId, score);
        }

        public void UpdateScore(Score score)
        {
            if (IsFinal)
                throw new DomainException("Final grade cannot be updated.");

            Score = score;
        }

        public void FinalizeGrade()
        {
            if (IsFinal)
                throw new DomainException("Grade is already final.");

            IsFinal = true;

            AddDomainEvent(new GradeFinalizedDomainEvent(
                GradeId,
                StudentId,
                SubjectId
            ));
        }
    }
}
