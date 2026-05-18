namespace PeopleDirectory.Core.Interfaces;

public interface IEmailService
{
    Task SendAsync(string subject, string body);
}