using DemoDDD.Application.Abstractions.Messaging;
using DemoDDD.Application.Rentals.ReserveRent;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DemoDDD.Application.Abstractions.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken
            )
        {
            var name = request.GetType().Name;
            if (name == nameof(ReserveRentDomainEventHandler))
            {
            }

            try
            {
                _logger.LogInformation($"Executing Command Request: {name}");
                var result = await next();
                _logger.LogInformation($"Command executed successfully");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Command {name} failed to execute");
                throw;
            }
        }
    }
}
