using DemoDDD.Domain.Vehicles;

namespace DemoDDD.Domain.Rentals
{
    public interface IRentRepository
    {
        Task<Rental?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> IsOverlappingAsync(Vehicle vehicle, DateRange dateRange, CancellationToken cancellationToken = default);
        void Add(Rental? user);
    }
}
