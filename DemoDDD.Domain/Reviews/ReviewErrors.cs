using DemoDDD.Domain.Abstractions;

namespace DemoDDD.Domain.Reviews
{
    public class ReviewErrors
    {
        public static readonly Error NotElegible = new Error(
            "Review.NotEligible", 
            "Review is not available for this vehicle while rent is not completed"
        );
    }
}
