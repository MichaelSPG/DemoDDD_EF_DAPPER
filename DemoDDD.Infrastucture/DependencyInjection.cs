using Dapper;
using DemoDDD.Application.Abstractions.Clock;
using DemoDDD.Application.Abstractions.Data;
using DemoDDD.Application.Abstractions.Email;
using DemoDDD.Domain.Abstractions;
using DemoDDD.Domain.Rentals;
using DemoDDD.Domain.Users;
using DemoDDD.Domain.Vehicles;
using DemoDDD.Infrastucture.Clock;
using DemoDDD.Infrastucture.Data;
using DemoDDD.Infrastucture.Email;
using DemoDDD.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoDDD.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IEmailService, EmailService>();

            var connectionString = configuration.GetConnectionString("Database") 
                ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                //.UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVehicleRepository, VechicleRepository>();
            services.AddScoped<IRentRepository, RentalRepository>();
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ => 
                new SqlConnectionFactory(connectionString)
            );
            // Add DateOnly TypeHandler
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
            return services;
        }
    }
}
