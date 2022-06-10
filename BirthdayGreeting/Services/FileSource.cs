using BirthdayGreetings.Domain;

namespace BirthdayGreetings.Services
{
    public class FileSource : IDataSource
    {
        private readonly string filePath;

        public FileSource(string filePath)
        {
            this.filePath = filePath;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> result = new();

            string[] lines = File.ReadAllLines(this.filePath);

            if (!lines.Any())
            {
                return Array.Empty<Employee>();
            }

            foreach (string line in lines.Skip(1))
            {
                string[] employeeProperties = line.Split(", ");

                result.Add(new Employee(
                    firstName: employeeProperties[1],
                    birthday: DateOnly.Parse(employeeProperties[2]),
                    email: employeeProperties[3]));
            }

            return result;
        }
    }
}