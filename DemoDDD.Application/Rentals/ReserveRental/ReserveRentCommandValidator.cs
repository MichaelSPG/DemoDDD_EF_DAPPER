using DemoDDD.Application.Rentals.ReserveRent;
using FluentValidation;

namespace DemoDDD.Application.Rentals.ReserveRental
{
    public class ReserveRentCommandValidator : AbstractValidator<ReserveRentCommand>
    {
        public ReserveRentCommandValidator() 
        {
            RuleFor(c=> c.UserId).NotEmpty();
            RuleFor(c => c.VehicleId).NotEmpty();
            RuleFor(c => c.StartDate).LessThan(c=> c.EndDate);
        }
    }
}
