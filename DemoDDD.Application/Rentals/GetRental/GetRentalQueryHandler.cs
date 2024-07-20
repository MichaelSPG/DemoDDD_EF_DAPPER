using Dapper;
using DemoDDD.Application.Abstractions.Data;
using DemoDDD.Application.Abstractions.Messaging;
using DemoDDD.Domain.Abstractions;

namespace DemoDDD.Application.Rentals.GetRental
{
    internal sealed class GetRentalQueryHandler : IQueryHandler<GetRentalQuery, RentResponse>
    {
        public readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetRentalQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<RentResponse>> Handle(
            GetRentalQuery request, 
            CancellationToken cancellationToken
            )
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = """
                        SELECT * 
                        FROM Rental 
                        WHERE Id = @RentalId
                """;

            var rent = await connection.QueryFirstOrDefaultAsync<RentResponse>(
                sql,
                new {
                    request.RentalId
                }
            );
            return rent;
        }
    }
}
