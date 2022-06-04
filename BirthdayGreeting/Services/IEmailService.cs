using BirthdayGreetings.Domain;

namespace BirthdayGreetings.Services
{
    public interface IEmailService
    {
        void Send(IEnumerable<Email> emails);
    }
}