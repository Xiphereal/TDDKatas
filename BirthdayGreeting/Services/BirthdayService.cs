using BirthdayGreetings.Domain;

namespace BirthdayGreetings.Services
{
    public class BirthdayService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmailService emailService;

        public BirthdayService(
            IEmployeeRepository employeeRepository,
            IEmailService emailService)
        {
            this.employeeRepository = employeeRepository;
            this.emailService = emailService;
        }

        public void SendGreetings(DateOnly forDate)
        {
            IEnumerable<Employee> employees =
                this.employeeRepository.GetEmployees();

            if (!employees.Any())
                return;

            IEnumerable<string> employeesToGreetMails = employees
                .Where(e => e.Birthday.Equals(forDate))
                .Select(e => e.Email);

            if (!employeesToGreetMails.Any())
                return;

            this.emailService.SendTo(employeesToGreetMails);
        }
    }
}