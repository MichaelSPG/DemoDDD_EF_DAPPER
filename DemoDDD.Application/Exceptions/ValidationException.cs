using DemoDDD.Application.Abstractions.Behaviors;
using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    public sealed class ValidationException : Exception
    {
        private IEnumerable<ValidationError> ValidationErrors { get; }


        public ValidationException(IEnumerable<ValidationError> validationErrors)
        {
            ValidationErrors = validationErrors;
        }

    }
}