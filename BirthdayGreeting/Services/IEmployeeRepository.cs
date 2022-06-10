using BirthdayGreetings.Domain;

namespace BirthdayGreetings.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
    }
}