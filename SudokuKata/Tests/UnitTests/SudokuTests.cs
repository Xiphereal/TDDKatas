using FluentAssertions;
using Xunit;
using static SudokuKata.Tests.Builders.MatrixBuilder;

namespace SudokuKata.Tests.UnitTests
{
    public class SudokuTests
    {
        [Fact]
        public void Correct_proposed_solution_is_recognized_as_such()
        {
            Matrix initialGrid =
                Matrix()
                    .WithRow(new EmptyCell(), new Cell(1))
                    .WithRow(new Cell(1), new Cell(2))
                    .Build();

            var sut = new Sudoku(initialGrid);

            sut.IsSolution(
                Matrix()
                    .WithRow(new Cell(2), new Cell(1))
                    .WithRow(new Cell(1), new Cell(2))
                    .Build())
                .Should().Be("The proposed solution is correct");
        }

        [Fact]
        public void Incorrect_proposed_solution_is_recognized_as_such()
        {
            Matrix initialGrid =
                Matrix()
                    .WithRow(new EmptyCell(), new Cell(1))
                    .WithRow(new Cell(1), new Cell(2))
                    .Build();

            var sut = new Sudoku(initialGrid);

            sut.IsSolution(
                Matrix()
                    .WithRow(new Cell(1), new Cell(1))
                    .WithRow(new Cell(1), new Cell(2))
                    .Build())
                .Should().Be("The proposed solution is incorrect");
        }
    }
}