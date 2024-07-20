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

            var sql = """
                        SELECT * 
                        FROM Vechicle AS a
                        WHERE NOT EXIST
                        (
                            select 1
                            FROM Rental AS b
                            WHERE
                                b.VechicleId = a.Id AND
                                b.StartDate <= @startDate AND
                                b.EndDate >= @endDate AND
                                b.Status in (@ActiveRentStatuses)
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
                    ActiveRentStatuses
                },
                splitOn: "Address"

            );

            return vechicles.ToList();
        }
    }
}
