namespace BirthdayGreetings.Domain
{
    public class Employee
    {
        public object FirstName { get; set; }
        public DateOnly Birthday { get; }
        public string Email { get; }

        public Employee(string firstName, DateOnly birthday, string email)
        {
            this.FirstName = firstName;
            this.Birthday = birthday;
            this.Email = email;
        }
    }
}