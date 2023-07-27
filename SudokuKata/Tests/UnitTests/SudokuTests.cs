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
                    .WithRow(new EmptyCell(), new Cell(2))
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

        [Fact]
        public void Non_solvable_Sudoku_is_recognized_when_trying_to_solve_it()
        {
            new Sudoku(
                Matrix()
                    .WithRow(new Cell(1), new EmptyCell())
                    .WithRow(1, 2)
                    .Build())
                .ProposeSolution()
                .Should().Be("The Sudoku is not solvable");
        }

        [Fact]
        public void Solvable_Sudoku()
        {
            new Sudoku(
                Matrix()
                    .WithRow(new Cell(2), new EmptyCell())
                    .WithRow(1, 2)
                    .Build())
                .ProposeSolution()
                .Should().Be("TODO");
        }
    }
}