using Bogus;
using Dapper;
using DemoDDD.Application.Abstractions.Data;
using DemoDDD.Domain.Vehicles;

namespace DemoDDD.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();

        using var connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker();

        List<object> vehicles = new List<object>();

        for (int i = 0; i < 100; i++)
        {
            vehicles.Add(new
            {
                Id = Guid.NewGuid(),
                Vin = faker.Vehicle.Vin(),
                Model = faker.Vehicle.Model(),
                Country = faker.Address.Country(),
                Province = faker.Address.County(),
                State = faker.Address.State(),
                City = faker.Address.City(),
                Street = faker.Address.StreetAddress(),
                Price = faker.Random.Decimal(1000, 20000),
                PriceCurrencyType = "USD",
                Maintenance = faker.Random.Decimal(100, 200),
                MaintenanceCurrencyType = "USD",
                Accesories = string.Join(";", new List<int> { (int)Accesory.Wifi, (int)Accesory.AppleCar }),
                LastRentDate = DateTime.Parse("1900/01/01")
            });
        }
        const string sql = @"
            INSERT INTO dbo.Vehicle
                (Id, Vin, Model, Address_Country, Address_State, Address_Province, Address_City, Address_Street, Price_Value, Price_CurrencyKind, MaintenanceAmount_Value, MaintenanceAmount_CurrencyKind, LastRentDate, Accesories)
                VALUES 
                (@Id, @Vin, @Model, @Country, @State, @Province, @City, @Street, @Price, @PriceCurrencyType, @Maintenance, @MaintenanceCurrencyType, @LastRentDate, @Accesories)";
        
        var sql2 = @"
            SELECT TABLE_NAME 
            FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = @DatabaseName";
        sql2 = @"INSERT INTO [dbo].[Vehicle]([Id], [Vin]) VALUES(@Id, @Vin)";
        var parameters = new { DatabaseName = "DDDTestingDB" };

        connection.Execute(sql, vehicles);
        //var tableNames = connection.Query<string>(sql2, parameters);

    }
}
