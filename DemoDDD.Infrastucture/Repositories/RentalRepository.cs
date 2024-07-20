using DemoDDD.Domain.Rentals;
using DemoDDD.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace DemoDDD.Infrastucture.Repositories;

internal sealed class RentalRepository : Repository<Rental>, IRentRepository
{
    public RentalRepository(ApplicationDbContext context) : base(context)
    {
    }

    private static readonly RentalStatus[] ActiveRentalStatuses =
    {
        RentalStatus.Reserved,
        RentalStatus.Confirmed,
        RentalStatus.Completed,
    };

    public async Task<bool> IsOverlappingAsync(
        Vehicle vehicle, 
        DateRange dateRange, 
        CancellationToken cancellationToken = default
        )
    {
        return await _context.Set<Rental>()
            .AnyAsync(
                r =>
                    r.VehicleId == vehicle.Id 
                    && r.Duration!.Start <= dateRange.End 
                    && r.Duration!.End >= dateRange.Start 
                    && ActiveRentalStatuses.Contains(r.Status),
                cancellationToken
            );    
    }
}
