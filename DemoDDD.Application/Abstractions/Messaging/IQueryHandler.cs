using DemoDDD.Domain.Abstractions;
using MediatR;

namespace DemoDDD.Application.Abstractions.Messaging
{
    public interface IQueryHandler<IQuery, TResponse> 
        : IRequestHandler<IQuery, Result<TResponse>>
        where IQuery : IQuery<TResponse>
    {
    }
}
