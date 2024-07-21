namespace DemoDDD.Api.Controllers.Rentals;

public sealed record RentRequest(
    Guid VechicleId,
    Guid UserId,
    DateTime StartDate,
    DateTime EndDate
);
