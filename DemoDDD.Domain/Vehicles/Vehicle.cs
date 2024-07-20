using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoDDD.Domain.Abstractions;
using DemoDDD.Domain.Shared;

namespace DemoDDD.Domain.Vehicles
{
    public sealed class Vehicle : Entity
    {
        private Vehicle()
        {

        }
        public Vehicle(
            Guid id,
            Model model, 
            Vin vin, 
            Address address, 
            Currency price, 
            Currency maintenanceAmount, 
            DateTime lastRentDate,
            List<Accesories> accesories)
            : base(id)
        {
            Model = model;
            Vin = vin;
            Address = address;
            Price = price ?? throw new ArgumentNullException(nameof(price));
            MaintenanceAmount = maintenanceAmount ?? throw new ArgumentNullException(nameof(maintenanceAmount));
            LastRentDate = lastRentDate;
            Accesories = accesories ?? throw new ArgumentNullException(nameof(accesories));
        }

        public Model?   Model{ get; private set; }
        public Vin?     Vin { get; private set; }
        public Address? Address{ get; private set; }
        public Currency Price { get; private set; }
        public Currency MaintenanceAmount { get; private set; }
        public DateTime? LastRentDate{ get; internal set; }
        public List<Accesories> Accesories { get; private set; } = new();
    }
}
