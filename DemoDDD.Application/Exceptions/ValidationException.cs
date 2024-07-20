using DemoDDD.Application.Abstractions.Behaviors;

namespace DemoDDD.Application.Exceptions
{
    public sealed class ValidationException : Exception
    {
        private IEnumerable<ValidationError> ValidationErrors { get; }

        public ValidationException(IEnumerable<ValidationError> validationErrors)
        {
            ValidationErrors = validationErrors;
        }
    }
}