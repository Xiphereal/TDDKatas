using FluentAssertions;
using Xunit;
using static SudokuKata.Tests.Builders.MatrixBuilder;

namespace SudokuKata.Tests.UnitTests
{
    public class SudokuTests
    {
        [Fact]
        public void Proposed_solution_that_fills_empty_cell_complying_with_Sudokus_rules_is_correct()
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
        public void Proposed_solution_violating_Sudokus_rules_is_incorrect()
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

        [Fact]
        public void Proposed_solution_with_numbers_not_matching_initial_grid_is_incorrect()
        {
            Matrix initialGrid =
                Matrix()
                    .WithRow(1, 2)
                    .WithRow(2, 1)
                    .Build();

            var sut = new Sudoku(initialGrid);

            sut.IsSolution(
                Matrix()
                    .WithRow(2, 1)
                    .WithRow(1, 2)
                    .Build())
                .Should().Be("The proposed solution is incorrect");
        }
    }
}