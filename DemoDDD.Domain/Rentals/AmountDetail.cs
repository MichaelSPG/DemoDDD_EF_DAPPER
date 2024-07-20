using DemoDDD.Domain.Shared;

namespace DemoDDD.Domain.Rentals
{
    public record AmountDetail( Currency PricePerPeriod,
                                Currency Maintenance,
                                Currency Accesories,
                                Currency Total);
}
