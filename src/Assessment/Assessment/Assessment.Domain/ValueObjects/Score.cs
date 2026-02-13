using Assessment.Domain.Exceptions;
using BuildingBlocks.Domain;

namespace Assessment.Domain.ValueObjects
{
    public sealed class Score : ValueObject<Score>
    {
        public decimal Value { get; }

        private Score(decimal value)
        {
            if (value < 0 || value > 100)
                throw new DomainException("Score must be between 0 and 100.");

            Value = value;
        }

        public static Score From(decimal value) => new(value);

        protected override bool EqualsCore(Score other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
