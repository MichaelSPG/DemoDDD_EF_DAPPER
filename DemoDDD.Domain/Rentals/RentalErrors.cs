using DemoDDD.Domain.Abstractions;

namespace DemoDDD.Domain.Rentals
{
    public static class RentalErrors
    {
        public static Error NotFound = new Error(
            "Rent.NotFound", 
            "Rent ID was not found"
        );

        public static Error Overlap = new Error(
            "Rent.Overlap",
            "Vehicle is rented in the provided date range"
        );

        public static Error NotRerserved = new Error(
            "Rent.NotRerserved",
            "Vehicle is not confirmed"
        );

        public static Error NotConfirmed = new Error(
            "Rent.NotConfirmed",
            "Rental is not confirmed"
        );

        public static Error AlreadyStarted = new Error(
            "Rent.AlreadyStarted",
            "Rental has already started"
        );
    }
}
