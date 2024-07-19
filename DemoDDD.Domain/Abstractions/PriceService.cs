using DemoDDD.Domain.Rentals;
using DemoDDD.Domain.Shared;
using DemoDDD.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Domain.Abstractions
{
    public class PriceService
    {
        public AmountDetail CalculatePrice(Vehicle vehicle, DateRange range)
        {
            var currencyType = vehicle.Price!.CurrencyKind;

            var perPeriodPrice = new Currency(
                range.DaysCount * vehicle.Price.Value, 
                currencyType);
            var accesoriesPercent = 0.0m;
            foreach (var item in vehicle.Accesories)
            {
                accesoriesPercent += item switch
                {
                    Accesories.AppleCar or Accesories.AndroidCar => 0.05m,
                    Accesories.AirConditioning => 0.02m,
                    Accesories.Maps => 0.01m,
                    _ => 0.0m
                };
            }

            var accesoriesCharges = Currency.Zero();

            if(accesoriesPercent > 0)
            {
                accesoriesCharges = new Currency(accesoriesPercent * perPeriodPrice.Value, currencyType);
            }
            var totalAmount = Currency.Zero();
            totalAmount += perPeriodPrice;

            if(!vehicle!.MaintenanceAmount!.IsZero())
            {
                totalAmount += vehicle.MaintenanceAmount;
            }
            totalAmount += accesoriesCharges;

            return new AmountDetail(perPeriodPrice, vehicle.MaintenanceAmount, accesoriesCharges, totalAmount);
        }
    }
}
