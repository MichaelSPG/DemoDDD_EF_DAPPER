using DemoDDD.Application.Abstractions.Email;
using DemoDDD.Domain.Rentals;
using DemoDDD.Domain.Rentals.Events;
using DemoDDD.Domain.Users;
using MediatR;

namespace DemoDDD.Application.Rentals.ReserveRent
{
    internal sealed class ReserveRentDomainEventHandler : INotificationHandler<RentalReservedDomainEvent>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRentRepository _rentRepository;
        private readonly IEmailService _emailService;

        public ReserveRentDomainEventHandler(
            IUserRepository userRepository, 
            IRentRepository rentRepository, 
            IEmailService emailService)
        {
            _userRepository = userRepository;
            _rentRepository = rentRepository;
            _emailService = emailService;
        }

        public async Task Handle(
            RentalReservedDomainEvent notification, 
            CancellationToken cancellationToken
        )
        {
            var rent = await _rentRepository.GetByIdAsync(notification.RentId, cancellationToken);
            if(rent == null)
            {
                return;
            }
            
            var user = await _userRepository.GetByIdAsync(rent.UserId, cancellationToken);
            if(user is null)
            {
                return;
            }

            await _emailService.SendEmailAsync(
                user.Email,
                "Your rental is reserved!", "Please confirm the reserve or it can be lost!");
        }
    }
}
