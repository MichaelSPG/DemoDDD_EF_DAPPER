namespace DemoDDD.Application.Rentals.GetRental
{
    public sealed class RentResponse
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public Guid VehicleId { get; init; }
        public int Status{ get; init; }
        public decimal RentAmount{ get; init; }
        public string? RentCurrencyType { get; init; }
        public decimal MaintenanceAmout { get; init; }
        public string? MaintenanceCurrencyType { get; init; }

        public decimal AccesoriesAmout { get; init; }
        public string? AccesoriesCurrencyType { get; init; }

        public decimal TotalAmout { get; init; }
        public string? TotalAmountCurrencyType { get; init; }

        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }
        public DateTime CreationDate{ get; init; }
    }
}
