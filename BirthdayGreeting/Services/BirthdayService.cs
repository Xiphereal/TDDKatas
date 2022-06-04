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

            IEnumerable<Email> mailsToEmployeesWhoseBirthdayIsToday = employees
                .Where(e => e.Birthday.Equals(forDate))
                .Select(e => new Email(
                    to: e.Email,
                    subject: "Happy birthday!",
                    message: $"Happy birthday, dear {e.FirstName}!"));

            if (!mailsToEmployeesWhoseBirthdayIsToday.Any())
                return;

            this.emailService.Send(mailsToEmployeesWhoseBirthdayIsToday);
        }
    }
}