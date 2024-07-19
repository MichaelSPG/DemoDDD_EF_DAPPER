using DemoDDD.Domain.Abstractions;
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
            });

            services.AddTransient<PriceService>();
            return services;
        }
    }
}
