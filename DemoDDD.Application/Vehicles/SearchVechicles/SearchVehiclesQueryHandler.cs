using Dapper;
using DemoDDD.Application.Abstractions.Data;
using DemoDDD.Application.Abstractions.Messaging;
using DemoDDD.Domain.Abstractions;
using DemoDDD.Domain.Rentals;

namespace DemoDDD.Application.Vehicles.SearchVechicles
{
    internal class SearchVehiclesQueryHandler : IQueryHandler<SearchVehiclesQuery, IReadOnlyList<VehicleResponse>>
    {
        public static readonly int[] ActiveRentStatuses =
        {
            (int)RentalStatus.Reserved,
            (int)RentalStatus.Confirmed,
            (int)RentalStatus.Completed,
        };

        public readonly ISqlConnectionFactory _sqlConnectionFactory;

        public SearchVehiclesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<Result<IReadOnlyList<VehicleResponse>>> Handle(
            SearchVehiclesQuery request, 
            CancellationToken cancellationToken)
        {
            if(request.startDate > request.endDate) 
            {
                return new List<VehicleResponse>();
            }
            using var connection = _sqlConnectionFactory.CreateConnection();

            var statusStr = string.Join(",", ActiveRentStatuses);
            var sql = $"""
                        SELECT 
                         a.[Id] as Id
                        ,a.[Model] as Model
                        ,a.[Vin] as Vin
                        ,a.[Price_Value] as Price
                        ,a.[Price_CurrencyKind] as CurencyType
                        ,a.[Address_Country] as Country
                        ,a.[Address_State] as State
                        ,a.[Address_Province] as Province
                        ,a.[Address_City] as City
                        ,a.[Address_Street] as Street
                        FROM Vehicle AS a
                        WHERE NOT EXISTS
                        (
                            select 1
                            FROM Rental AS b
                            WHERE
                                b.VehicleId = a.Id AND
                                b.Duration_Start <= @startDate AND
                                b.Duration_End >= @endDate AND
                                b.Status in ({statusStr})
                        )
                """;

            
            var vechicles = await connection.QueryAsync<VehicleResponse, AddressResponse, VehicleResponse>(
                sql,
                (vechicle, address) =>
                {
                    vechicle.Address = address;
                    return vechicle;
                },
                new
                {
                    request.startDate,
                    request.endDate,
                },
                splitOn: "Country"

            );

            return vechicles.ToList();
        }
    }
}
