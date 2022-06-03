using BirthdayGreetings.Domain;

namespace BirthdayGreetings
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
    }
}