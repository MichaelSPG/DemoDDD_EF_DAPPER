using DemoDDD.Domain.Abstractions;
using MediatR;

namespace DemoDDD.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
