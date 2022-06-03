namespace BirthdayGreetings.Services
{
    public interface IEmailService
    {
        void SendTo(IEnumerable<string> enumerable);
    }
}