using BirthdayGreetings.Domain;

namespace BirthdayGreetings.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDataSource fileSource;

        public EmployeeRepository(IDataSource dataSource)
        {
            this.fileSource = dataSource;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return this.fileSource.GetEmployees();
        }
    }
}