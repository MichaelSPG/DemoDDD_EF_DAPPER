using DemoDDD.Application.Abstractions.Behaviors;
using DemoDDD.Domain.Abstractions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DemoDDD.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            services.AddTransient<PriceService>();
            return services;
        }
    }
}
