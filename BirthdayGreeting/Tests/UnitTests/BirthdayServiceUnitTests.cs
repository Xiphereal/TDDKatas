using BirthdayGreetings.Domain;
using BirthdayGreetings.Services;
using Moq;
using System;
using System.Collections.Generic;
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

            List<Employee> employees = new() { new Employee(birthday: notToday) };

            // Arrange & Act & Assert.
            VerifyThat_no_greeting_is_sent_any_employee_whose_birthday_is_not_today(
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
                new Employee(birthday: notToday),
                new Employee(birthday: notToday),
            };

            // Arrange & Act & Assert.
            VerifyThat_no_greeting_is_sent_any_employee_whose_birthday_is_not_today(
                employees);
        }

        private static void VerifyThat_no_greeting_is_sent_any_employee_whose_birthday_is_not_today(IEnumerable<Employee> employees)
        {
            // Arrange.
            DateOnly today = new();
            DateOnly notToday = today.AddDays(1);

            Mock<IEmployeeRepository> employeeRepositoryMock =
                CreateEmployeeRepositoryMock(
                    employees: new List<Employee>() { new Employee(birthday: notToday) });

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

        private static void AssertThat_NoGreetingIsSent(Mock<IEmailService> emailServiceMock)
        {
            emailServiceMock.Verify(
                m => m.SendTo(It.IsAny<IEnumerable<string>>()),
                Times.Never());
        }
    }
}