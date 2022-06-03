namespace BirthdayGreetings.Domain
{
    public class Employee
    {
        public DateOnly Birthday { get; }
        public string Email { get; }

        public Employee(DateOnly birthday, string email)
        {
            this.Birthday = birthday;
            this.Email = email;
        }
    }
}