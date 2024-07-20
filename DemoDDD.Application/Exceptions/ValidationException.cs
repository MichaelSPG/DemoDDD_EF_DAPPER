using DemoDDD.Application.Abstractions.Behaviors;

namespace Exceptions
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