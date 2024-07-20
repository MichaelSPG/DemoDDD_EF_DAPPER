using DemoDDD.Domain.Abstractions;

namespace DemoDDD.Domain.Users
{
    public static class UserErrors
    {
        public static Error NotFound = new(
            "User.NotFound", 
            "User was not found by the specified Id"
            );

        public static Error InvalidCredentials = new(
            "User.InvalidCredentials", 
            "User credentials are invalid");
    }
}
