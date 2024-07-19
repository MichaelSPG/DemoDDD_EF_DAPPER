using DemoDDD.Domain.Abstractions;
using DemoDDD.Domain.Rentals.Events;
using DemoDDD.Domain.Shared;
using DemoDDD.Domain.Users;
using DemoDDD.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Domain.Rentals
{
    public sealed class Rental : Entity
    {
        private Rental(Guid id
            , RentalStatus status
            , Guid vehicleId
            , DateRange? duration
            , Currency? perPeriodPrice
            , Currency? maintenancePrice
            , Currency? accesories
            , Currency? totalPrice
            , DateTime creationDate
            , Guid userId)
            : base(id)
        {
            Status = status;
            VehicleId = vehicleId;
            Duration = duration;
            PerPeriodPrice = perPeriodPrice;
            MaintenancePrice = maintenancePrice;
            Accesories = accesories;
            TotalPrice = totalPrice;
            CreationDate = creationDate;
            UserId = userId;
        }

        public RentalStatus Status { get; private set; }
        public Guid VehicleId { get; private set; }
        public Guid UserId { get; private set; }
        public DateRange?  Duration { get; private set; }
        public Currency? PerPeriodPrice{ get; private set; }
        public Currency? MaintenancePrice { get; private set; }
        public Currency? Accesories { get; private set; }
        public Currency? TotalPrice { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ConfirmationDate { get; private set; }
        public DateTime RejectionDate { get; private set; }
        public DateTime CompletionDate { get; private set; }
        public DateTime CancellationDate { get; private set; }

        public static Rental Reserve(
              Vehicle vehicle
            , Guid userId
            , DateRange duration
            , DateTime creationTime,
              PriceService priceService)
        {

            var amountDetail = priceService.CalculatePrice(vehicle, duration);

            var rent = new Rental(
                Guid.NewGuid(),                           
                RentalStatus.Reserved,
                vehicle.Id,
                duration,
                amountDetail.PricePerPeriod,
                amountDetail.Maintenance,
                amountDetail.Accesories,
                amountDetail.Total,
                creationTime, userId
            );
            vehicle.LastRentDate = creationTime;
            rent.RaiseDomainEvent(new RentalReservedDomainEvent(rent.Id!));
            return rent;
        }

        public Result Confirm( DateTime utcNow )
        {
            if(Status != RentalStatus.Reserved)
            {
                Result.Failure(RentalErrors.NotRerserved);
            }
            Status = RentalStatus.Confirmed;
            ConfirmationDate = utcNow;
            
            RaiseDomainEvent(new RentalRejectedDomainEvent(Id));
            return Result.Success();
        }

        public Result Reject(DateTime utcNow)
        {
            if (Status != RentalStatus.Reserved)
            {
                Result.Failure(RentalErrors.NotRerserved);
            }
            Status = RentalStatus.Rejected;
            RejectionDate = utcNow;
            
            RaiseDomainEvent(new RentalRejectedDomainEvent(Id));
            return Result.Success();
        }

        public Result Cancel(DateTime utcNow)
        {
            if (Status != RentalStatus.Confirmed)
            {
                Result.Failure(RentalErrors.NotConfirmed);
            }

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duration!.Start)
            {
                return Result.Failure(RentalErrors.AlreadyStarted);
            }

            Status = RentalStatus.Canceled;
            CancellationDate = utcNow;
            RaiseDomainEvent(new RentalCancelledDomainEvent(Id));

            return Result.Success();
        }
        public Result Complete(DateTime utcNow)
        {
            if (Status != RentalStatus.Confirmed)
            {
                Result.Failure(RentalErrors.NotConfirmed);
            }

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duration!.Start)
            {
                return Result.Failure(RentalErrors.AlreadyStarted);
            }

            Status = RentalStatus.Completed;
            CompletionDate = utcNow;
            RaiseDomainEvent(new RentalCompletedDomainEvent(Id));

            return Result.Success();
        }
    }
}
