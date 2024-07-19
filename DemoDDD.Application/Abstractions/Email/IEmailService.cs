using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDDD.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Domain.Users.Email email, string subject, string body);
    }
}
