namespace DemoDDD.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Domain.Users.Email email, string subject, string body);
    }
}
