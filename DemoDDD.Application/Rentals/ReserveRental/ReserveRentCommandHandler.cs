using DemoDDD.Application.Abstractions.Messaging;
using DemoDDD.Domain.Abstractions;
using DemoDDD.Domain.Rentals;
using DemoDDD.Domain.Users;
using DemoDDD.Domain.Vehicles;

namespace DemoDDD.Application.Rentals.ReserveRent
{
    public sealed class ReserveRentCommandHandler
     : ICommandHandler<ReserveRentCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentRepository _rentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PriceService _priceService;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ReserveRentCommandHandler(
            IUserRepository userRepository,
            IVehicleRepository vehicleRepository,
            IRentRepository rentRepository,
            IUnitOfWork unitOfWork
,
            PriceService priceService,
            IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _vehicleRepository = vehicleRepository;
            _rentRepository = rentRepository;
            _unitOfWork = unitOfWork;
            _priceService = priceService;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(
            ReserveRentCommand request, 
            CancellationToken cancellationToken
            )
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
            if( user == null )
            {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }
            
            var vehicle = await _vehicleRepository.GetByIdAsync( request.VehicleId, cancellationToken );
            if (vehicle == null)
            {
                return Result.Failure<Guid>(VehicleErrors.NotFound);
            }
            
            var rentDays = DateRange.Create(request.StartDate, request.EndDate);

            if(await _rentRepository.IsOverlappingAsync(vehicle, rentDays, cancellationToken))
            {
                return Result.Failure<Guid>(RentalErrors.Overlap);
            }

            var rent = Rental.Reserve(
                vehicle, 
                user.Id, 
                rentDays,
                _dateTimeProvider.CurrentTime, 
                _priceService);

            _rentRepository.Add(rent);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return rent.Id;
        }
    }
}
