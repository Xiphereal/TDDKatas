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
                new Employee(birthday: today, email: "email"),
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
                new Employee(birthday: today, email: "email"),
                new Employee(birthday: today, email: "anotherEmail"),
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
                new Employee(birthday: today, email: "email"),
                new Employee(birthday: notToday, email: "anotherEmail"),
            };

            // Arrange & Act & Assert.
            VerifyThat_greeting_is_sent_to_employees_whose_birthday_is_today(
                today,
                employees);
        }

        private static Employee CreateEmployee(DateOnly birthday)
        {
            return new Employee(birthday: birthday, email: null);
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
                m => m.SendTo(It.IsAny<IEnumerable<string>>()),
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
            IEnumerable<string> employeesMailsWhoseBirthdayIsToday =
                employees.Where(e => e.Birthday.Equals(today)).Select(e => e.Email);

            emailServiceMock.Verify(
                m => m.SendTo(It.Is<IEnumerable<string>>(
                    ienum => ienum.SequenceEqual(employeesMailsWhoseBirthdayIsToday))));
        }
    }
}