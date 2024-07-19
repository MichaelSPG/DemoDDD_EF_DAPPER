using DemoDDD.Domain.Abstractions;

namespace DemoDDD.Domain.Reviews
{
    public sealed record Rating
    {
        public static readonly Error Invalid= new("Rating.Invalid", "Rating is not valid (1-5)");
        public int Value { get; set; }
        private Rating(int value) => Value = value;
        public static Result<Rating> Create(int value)
        {
            if(value < 1 || value > 5)
            {
                return Result.Failure<Rating>(Invalid);
            }

            return new Rating(value);
        }
    }
}