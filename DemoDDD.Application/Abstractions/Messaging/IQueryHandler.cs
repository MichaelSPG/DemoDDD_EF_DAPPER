using DemoDDD.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Application.Abstractions.Messaging
{
    public interface IQueryHandler<IQuery, TResponse> 
        : IRequestHandler<IQuery, Result<TResponse>>
        where IQuery : IQuery<TResponse>
    {
    }
}
