using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace SudokuKata.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void TestName()
        {
            var matrix = new Matrix();
            matrix.Rows.Add(new List<int> { 1, 2, 3, 4 });
            matrix.Rows.Add(new List<int> { 2, 1, 4, 3 });
            matrix.Rows.Add(new List<int> { 3, 4, 1, 2 });
            matrix.Rows.Add(new List<int> { 4, 3, 2, 1 });

            CsvReader.Read(path: "Input.csv")
                .Should().BeEquivalentTo(matrix);
        }
    }
}