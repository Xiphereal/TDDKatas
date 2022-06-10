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
        public void Reading_single_employee_record()
        {
            // Arrange.
            const string FilePath = "FilePath";

            const string FirstName = "FirstName";
            DateOnly birthday = new();
            string email = "Email";

            CreateFileWithHeaderAndEmployeeRecord(
                filePath: FilePath,
                firstName: FirstName,
                birthday: birthday,
                email: email);

            EmployeeRepository employeeRepository = new(dataSource: new FileSource(FilePath));

            // Act.
            IEnumerable<Employee> result = employeeRepository.GetEmployees();

            // Arrange.
            result.Should().BeEquivalentTo(
                new List<Employee>() { new Employee(FirstName, birthday, email) },
                options => options.ComparingByMembers<Employee>());
        }

        private static void CreateFileWithHeaderAndEmployeeRecord(string filePath, string firstName, DateOnly birthday, string email)
        {
            StreamWriter streamWriter = File.CreateText(filePath);

            streamWriter.WriteLine("last_name, first_name, date_of_birth, email");
            streamWriter.WriteLine($"LastName, {firstName}, {birthday}, {email}");

            streamWriter.Close();
        }

        private static void CreateEmptyFileAt(string filePath)
        {
            File.CreateText(filePath).Close();
        }
    }
}