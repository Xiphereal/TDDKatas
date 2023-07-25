using FluentAssertions;
using Xunit;
using static SudokuKata.Tests.Builders.MatrixBuilder;

namespace SudokuKata.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void TestName()
        {
            var matrix = Matrix()
                .WithRow(1, 2, 3, 4)
                .WithRow(2, 1, 4, 3)
                .WithRow(3, 4, 1, 2)
                .WithRow(4, 3, 2, 1)
                .Build();

            CsvReader.Read(path: "Input.csv")
                .Should().BeEquivalentTo(matrix);
        }
    }
}