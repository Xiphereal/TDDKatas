using BirthdayGreetings.Domain;

namespace BirthdayGreetings.Services
{
    public interface IDataSource
    {
        IEnumerable<Employee> GetEmployees();
    }
}