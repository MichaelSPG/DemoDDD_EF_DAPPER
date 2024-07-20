using DemoDDD.Domain.Vehicles;

namespace DemoDDD.Infrastucture.Repositories;

internal sealed class VechicleRepository : Repository<Vehicle>, IVehicleRepository
{
    public VechicleRepository(ApplicationDbContext context) : base(context)
    {
    }
}
