using DemoDDD.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
