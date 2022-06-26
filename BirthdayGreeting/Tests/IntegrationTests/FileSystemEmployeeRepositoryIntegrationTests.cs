using BirthdayGreetings.Domain;
using BirthdayGreetings.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace BirthdayGreetings.Tests.IntegrationTests
{
    public class FileSystemEmployeeRepositoryIntegrationTests
    {
        [Fact]
        public void Reading_from_empty_file()
        {
            // Arrange.
            const string FilePath = "FilePath";
            CreateEmptyFileAt(FilePath);

            EmployeeRepository employeeRepository = new(dataSource: new FileSource(FilePath));

            // Act.
            IEnumerable<Employee> result = employeeRepository.GetEmployees();

            // Arrange.
            result.Should().BeEmpty();
        }

        [Fact]
        public void Reading_from_file_with_only_the_header()
        {
            // Arrange.
            const string FilePath = "FilePath";
            CreateFileWithHeaderAndEmployeesRecords(filePath: FilePath, Array.Empty<Employee>());

            EmployeeRepository employeeRepository = new(dataSource: new FileSource(FilePath));

            // Act.
            IEnumerable<Employee> result = employeeRepository.GetEmployees();

            // Arrange.
            result.Should().BeEmpty();
        }

        [Fact]
        public void Reading_single_employee_record()
        {
            const string AFirstName = "AFirstName";
            DateOnly aBirthday = new();
            string anEmail = "AnEmail";

            VerifyThat_SeveralEmployeesRecordsCanBeReadFromFile(
                new Employee(AFirstName, aBirthday, anEmail));
        }

        [Fact]
        public void Reading_several_employees_records()
        {
            const string AFirstName = "AFirstName";
            DateOnly aBirthday = new();
            string anEmail = "AnEmail";

            const string AnotherFirstName = "AnotherFirstName";
            DateOnly anotherBirthday = aBirthday.AddDays(1);
            string anotherEmail = "AnotherEmail";

            VerifyThat_SeveralEmployeesRecordsCanBeReadFromFile(
                new Employee(AFirstName, aBirthday, anEmail),
                new Employee(AnotherFirstName, anotherBirthday, anotherEmail));
        }

        private static void VerifyThat_SeveralEmployeesRecordsCanBeReadFromFile(params Employee[] employees)
        {
            // Arrange.
            const string FilePath = "FilePath";

            CreateFileWithHeaderAndEmployeesRecords(filePath: FilePath, employees);

            EmployeeRepository employeeRepository = new(dataSource: new FileSource(FilePath));

            // Act.
            IEnumerable<Employee> result = employeeRepository.GetEmployees();

            // Arrange.
            result.Should().BeEquivalentTo(
                employees,
                options => options.ComparingByMembers<Employee>());
        }

        private static void CreateFileWithHeaderAndEmployeesRecords(
            string filePath,
            params Employee[] employees)
        {
            StreamWriter streamWriter = File.CreateText(filePath);

            streamWriter.WriteLine("last_name, first_name, date_of_birth, email");

            foreach (Employee employee in employees)
            {
                streamWriter.WriteLine(
                    $"LastName, {employee.FirstName}, {employee.Birthday}, {employee.Email}");
            }

            streamWriter.Close();
        }

        private static void CreateEmptyFileAt(string filePath)
        {
            File.CreateText(filePath).Close();
        }
    }
}