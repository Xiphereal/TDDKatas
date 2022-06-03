namespace BirthdayGreetings.Domain
{
    public class Employee
    {
        public DateOnly Birthday { get; }
        public string Email { get; }

        public Employee(DateOnly birthday)
        {
            this.Birthday = birthday;
        }
    }
}