using DemoDDD.Application.Abstractions.Email;

namespace DemoDDD.Infrastucture.Email;

public sealed class EmailService : IEmailService
{
    public Task<bool> SendEmailAsync(
        Domain.Users.Email email, 
        string subject, 
        string body
        )
    {
        return Task.FromResult( true );
    }
}
