using DemoDDD.Domain.Abstractions;
using DemoDDD.Domain.Rentals;
using DemoDDD.Domain.Reviews.Events;

namespace DemoDDD.Domain.Reviews
{
    public sealed class Review : Entity
    {
        private Review() 
        {
        }
        private Review(Guid id, Guid vehicleId, Guid rentId, Guid userId, Rating rating, Commentary commentary, DateTime creationDate)
            :base(id)
        {
            VehicleId = vehicleId;
            RentId = rentId;
            UserId = userId;
            Rating = rating;
            Commentary = commentary;
            CreationDate = creationDate;
        }

        public Guid VehicleId { get; private set; }
        public Guid RentId { get; private set; }
        public Guid UserId { get; private set; }
        public Rating Rating { get; private set; }
        public Commentary? Commentary { get; private set; }
        public DateTime CreationDate { get; private set; }

        public static Result<Review> Create(Guid vehicleId, Rental rent, Guid userId, Rating rating, Commentary commentary, DateTime creationDate)
        {
            if(rent.Status != RentalStatus.Completed)
            {
                return Result.Failure<Review>(ReviewErrors.NotElegible);
            }
            var review = new Review(
                Guid.NewGuid(), 
                vehicleId, 
                rent.Id, 
                userId, 
                rating, 
                commentary, 
                creationDate
            );

            review.RaiseDomainEvent(new ReviewCreatedDomainEvent(rent.Id));
            return Result.Success(review);
        }
    }
}
