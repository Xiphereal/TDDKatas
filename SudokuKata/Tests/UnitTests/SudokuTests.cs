using FluentAssertions;
using System;
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
                    .WithRow(new Cell(), new Cell(1))
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
                    .WithRow(new Cell(), new Cell(1))
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
                    .WithRow(new Cell(), new Cell(2))
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
        public void Proposed_solution_with_empty_cells_is_incorrect()
        {
            Matrix initialGrid =
                Matrix()
                    .WithRow(new Cell(), new Cell(2))
                    .WithRow(2, 1)
                    .Build();

            var sut = new Sudoku(initialGrid);

            sut.IsSolution(
                Matrix()
                    .WithRow(new Cell(), new Cell(2))
                    .WithRow(2, 1)
                    .Build())
                .Should().Be("The proposed solution is incorrect");
        }

        [Fact]
        public void Non_solvable_Sudoku_is_recognized_when_trying_to_solve_it()
        {
            new Sudoku(
                Matrix()
                    .WithRow(new Cell(1), new Cell())
                    .WithRow(1, 2)
                    .Build())
                .ProposeSolution()
                .Should().Be("The Sudoku is not solvable");
        }

        [Fact]
        public void Solution_can_be_proposed_for_single_empty_cell()
        {
            new Sudoku(
                Matrix()
                    .WithRow(new Cell(2), new Cell())
                    .WithRow(1, 2)
                    .Build())
                .ProposeSolution()
                .Should().Be(
                    "2,1," + Environment.NewLine +
                    "1,2,");
        }

        // WIP
        public void Solution_can_be_proposed_for_several_empty_cells()
        {
            new Sudoku(
                Matrix()
                    .WithRow(new Cell(), new Cell(2), new Cell(3))
                    .WithRow(new Cell(2), new Cell(), new Cell(1))
                    .WithRow(new Cell(3), new Cell(1), new Cell())
                    .Build())
                .ProposeSolution()
                .Should().Be(
                    "1,2,3" + Environment.NewLine +
                    "2,3,1" + Environment.NewLine +
                    "3,1,2");
        }
    }
}