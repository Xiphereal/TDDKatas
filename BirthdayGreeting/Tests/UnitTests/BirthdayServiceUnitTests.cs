using BirthdayGreetings.Domain;
using BirthdayGreetings.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BirthdayGreetings.Tests.UnitTests
{
    public class BirthdayServiceUnitTests
    {
        private const string AMailAdress = "email";
        private const string AnotherMailAdress = "anotherEmail";
        private const string AFirstName = "FirstName";
        private const string AnotherFirstName = "AnotherFirstName";

        [Fact]
        public void No_greeting_is_sent_when_there_are_no_employees()
        {
            // Arrange.
            Mock<IEmployeeRepository> employeeRepositoryMock =
                CreateEmployeeRepositoryMock(employees: Array.Empty<Employee>());

            Mock<IEmailService> emailServiceMock = new();

            BirthdayService birthdayService =
                new(employeeRepositoryMock.Object, emailServiceMock.Object);

            DateOnly anyDate = DateOnly.MinValue;

            // Act.
            birthdayService.SendGreetings(forDate: anyDate);

            // Assert.
            AssertThat_NoGreetingIsSent(emailServiceMock);
        }

        [Fact]
        public void No_greeting_is_sent_to_employee_whose_birthday_is_not_today()
        {
            DateOnly today = new();
            DateOnly notToday = today.AddDays(1);

            List<Employee> employees = new() { CreateEmployee(notToday) };

            // Arrange & Act & Assert.
            VerifyThat_no_greeting_is_sent_any_employee_whose_birthday_is_not_today(
                today,
                employees);
        }

        [Fact]
        public void No_greeting_is_sent_to_employees_whose_birthday_is_not_today()
        {
            // Arrange.
            DateOnly today = new();
            DateOnly notToday = today.AddDays(1);

            List<Employee> employees = new()
            {
                CreateEmployee(birthday: notToday),
                CreateEmployee(birthday: notToday),
            };

            // Arrange & Act & Assert.
            VerifyThat_no_greeting_is_sent_any_employee_whose_birthday_is_not_today(
                today,
                employees);
        }

        [Fact]
        public void Send_greeting_to_employee_whose_birthday_is_today()
        {
            // Arrange.
            DateOnly today = new();

            List<Employee> employees = new()
            {
                new Employee(AFirstName, birthday: today, AMailAdress),
            };

            // Arrange & Act & Assert.
            VerifyThat_greeting_is_sent_to_employees_whose_birthday_is_today(
                today,
                employees);
        }

        [Fact]
        public void Send_greeting_to_employees_whose_birthday_is_today()
        {
            // Arrange.
            DateOnly today = new();

            List<Employee> employees = new()
            {
                new Employee(AFirstName, birthday: today, AMailAdress),
                new Employee(AnotherFirstName, birthday: today, AnotherMailAdress),
            };

            // Arrange & Act & Assert.
            VerifyThat_greeting_is_sent_to_employees_whose_birthday_is_today(
                today,
                employees);
        }

        [Fact]
        public void Send_greeting_only_to_employees_whose_birthday_is_today()
        {
            // Arrange.
            DateOnly today = new();
            DateOnly notToday = today.AddDays(1);

            List<Employee> employees = new()
            {
                new Employee(AFirstName, birthday: today, AMailAdress),
                new Employee(AnotherFirstName, birthday: notToday, AnotherMailAdress),
            };

            // Arrange & Act & Assert.
            VerifyThat_greeting_is_sent_to_employees_whose_birthday_is_today(
                today,
                employees);
        }

        private static Employee CreateEmployee(DateOnly birthday)
        {
            return new Employee(firstName: null, birthday: birthday, email: null);
        }

        private static void VerifyThat_no_greeting_is_sent_any_employee_whose_birthday_is_not_today(
            DateOnly today,
            IEnumerable<Employee> employees)
        {
            // Arrange.
            Mock<IEmployeeRepository> employeeRepositoryMock =
                CreateEmployeeRepositoryMock(employees);

            Mock<IEmailService> emailServiceMock = new();

            BirthdayService birthdayService =
                new(employeeRepositoryMock.Object, emailServiceMock.Object);

            // Act.
            birthdayService.SendGreetings(forDate: today);

            // Assert.
            AssertThat_NoGreetingIsSent(emailServiceMock);
        }

        private static Mock<IEmployeeRepository> CreateEmployeeRepositoryMock(
            IEnumerable<Employee> employees)
        {
            Mock<IEmployeeRepository> employeeRepositoryMock = new();

            employeeRepositoryMock.Setup(m => m.GetEmployees()).Returns(employees);

            return employeeRepositoryMock;
        }

        private static void AssertThat_NoGreetingIsSent(
            Mock<IEmailService> emailServiceMock)
        {
            emailServiceMock.Verify(
                m => m.Send(It.IsAny<IEnumerable<Email>>()),
                Times.Never());
        }

        private static void VerifyThat_greeting_is_sent_to_employees_whose_birthday_is_today(
            DateOnly today,
            List<Employee> employees)
        {
            Mock<IEmployeeRepository> employeeRepositoryMock =
                CreateEmployeeRepositoryMock(employees);

            Mock<IEmailService> emailServiceMock = new();

            BirthdayService birthdayService =
                new(employeeRepositoryMock.Object, emailServiceMock.Object);

            // Act.
            birthdayService.SendGreetings(forDate: today);

            // Assert.
            IEnumerable<Email> mailsToEmployeesWhoseBirthdayIsToday =
                employees.Where(e => e.Birthday.Equals(today))
                .Select(e => new Email(
                    to: e.Email,
                    subject: "Happy birthday!",
                    message: $"Happy birthday, dear {e.FirstName}!"));

            emailServiceMock.Verify(
                m => m.Send(It.Is<IEnumerable<Email>>(
                    ienum => ienum.SequenceEqual(mailsToEmployeesWhoseBirthdayIsToday))));
        }
    }
}