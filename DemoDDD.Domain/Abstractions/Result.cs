using System.Diagnostics.CodeAnalysis;

namespace DemoDDD.Domain.Abstractions
{
    public class Result
    {
        public Result(bool isSuccess, Error error)
        {            
            if(isSuccess &&  error != Error.None)
            {
                throw new InvalidOperationException(nameof(error));
            }

            if (!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException(nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; set; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; set; }

        public static Result Success() => new (true, Error.None);
        public static Result Failure(Error error) => new(false, error);
        public static Result<TValue> Success<TValue>(TValue value)
            => new(value, true, Error.None);
        public static Result<TValue> Failure<TValue>(Error error)
            => new(default, false, error);

        public static Result<TValue> Create<TValue>(TValue? value)
            => value is not null
            ? Success(value) : Failure<TValue>(Error.NullValue);

        internal static Result<T> Failure<T>(object notElegible)
        {
            throw new NotImplementedException();
        }
    }

    public class Result<TValue> : Result
    {
        protected readonly TValue? _value;

        protected internal Result(TValue? value, bool isSuccess, Error error) 
            :base(isSuccess, error) 
        {
            _value = value;
        }

        [NotNull]
        public TValue? Value => IsSuccess
            ? _value! 
            : throw new InvalidOperationException("Value is not valid");

        public static implicit operator Result<TValue>(TValue? value) => Create(value);
    }
}
