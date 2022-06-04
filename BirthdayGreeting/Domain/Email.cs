namespace BirthdayGreetings.Domain
{
    public class Email
    {
        public string Recipient { get; }
        public string Subject { get; }
        public string Message { get; }

        public Email(string to, string subject, string message)
        {
            this.Recipient = to;
            this.Subject = subject;
            this.Message = message;
        }

        public override bool Equals(object? obj)
        {
            return obj is Email email &&
                this.Recipient == email.Recipient &&
                this.Subject == email.Subject &&
                this.Message == email.Message;
        }
    }
}