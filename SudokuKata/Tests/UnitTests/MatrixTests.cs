﻿using FluentAssertions;
using System.Linq;
using Xunit;
using static SudokuKata.Tests.Builders.MatrixBuilder;

namespace SudokuKata.Tests.UnitTests
{
    public class MatrixTests
    {
        [Fact]
        public void Compliant_matrix()
        {
            var matrix = Matrix()
                .WithRow(1, 2)
                .WithRow(2, 1)
                .Build();

            matrix.CheckForViolations().Should().Be("The input complies with Sudoku's rules.");
        }

        [Fact]
        public void Matrix_with_duplicated_numbers_in_row_is_noncompliant()
        {
            var matrix = Matrix()
                .WithRow(1, 1)
                .WithRow(2, 2)
                .Build();

            matrix.CheckForViolations().Should().Be("The input doesn't comply with Sudoku's rules.");
        }

        [Fact]
        public void Matrix_with_duplicated_numbers_in_column_is_noncompliant()
        {
            var matrix = Matrix()
                .WithRow(1, 2)
                .WithRow(1, 2)
                .Build();

            matrix.CheckForViolations().Should().Be("The input doesn't comply with Sudoku's rules.");
        }

        [Fact]
        public void Matrix_with_several_duplicated_numbers_in_both_columns_and_rows_is_noncompliant()
        {
            var matrix = Matrix()
                .WithRow(2, 1, 3, 4)
                .WithRow(3, 4, 1, 2)
                .WithRow(2, 3, 4, 1)
                .WithRow(3, 1, 2, 4)
                .Build();

            matrix.CheckForViolations().Should().Be("The input doesn't comply with Sudoku's rules.");
        }

        [Fact]
        public void Matrix_with_empty_cells_in_same_column_is_compliant()
        {
            var matrix = Matrix()
                .WithRow(new Cell(), new Cell(1))
                .WithRow(new Cell(), new Cell(2))
                .Build();

            matrix.CheckForViolations().Should().Be("The input complies with Sudoku's rules.");
        }

        [Fact]
        public void Columns_can_be_obtained_from_rows()
        {
            var matrix = Matrix()
                .WithRow(1, 2)
                .WithRow(1, 2)
                .Build();

            matrix.Columns.Should().BeEquivalentTo(new[]
            {
                new[] { new Cell(1), new Cell(1) },
                new[] { new Cell(2), new Cell(2) },
            });
        }

        [Fact]
        public void Matrix_can_have_empty_cells()
        {
            var matrix = Matrix()
                .WithRow(new Cell(), new Cell(1))
                .Build();

            matrix.Rows.Should().BeEquivalentTo(new[]
            {
                new[] { new Cell(), new Cell(1) }
            });
        }

        [Fact]
        public void Matrix_can_be_deep_cloned()
        {
            var original = Matrix()
                .WithRow(1, 2)
                .WithRow(2, 1)
                .Build();

            Matrix clone = original.DeepClone();

            clone.Should().BeEquivalentTo(original);

            original.Rows.First().First().Number = 99;

            clone.Rows.Any(r => r.Any(c => c.Number == 99)).Should().BeFalse();
        }

        [Fact]
        public void MaxNumberInMatrix()
        {
            Matrix()
                .WithRow(1, 9)
                .WithRow(1, 9)
                .Build()
            .MaxNumber
            .Should().Be(9);
        }

        [Fact]
        public void Calculate_available_candidate_numbers_in_row()
        {
            Matrix()
                .WithRow(new Cell(), new Cell(1))
                .WithRow(new Cell(), new Cell(2))
                .Build()
            .AvailableCandidateNumbersIn(rowIndex: 0)
            .Should().BeEquivalentTo(new[] { 2 });
        }

        [Fact]
        public void Calculate_available_candidate_numbers_in_row_triangulation()
        {
            Matrix()
                .WithRow(new Cell(), new Cell(1))
                .WithRow(new Cell(), new Cell(2))
                .Build()
            .AvailableCandidateNumbersIn(rowIndex: 1)
            .Should().BeEquivalentTo(new[] { 1 });
        }

        [Fact]
        public void Calculate_available_candidate_numbers_in_row_for_several_candidates()
        {
            Matrix()
                .WithRow(new Cell(), new Cell())
                .WithRow(new Cell(1), new Cell(2))
                .Build()
            .AvailableCandidateNumbersIn(rowIndex: 0)
            .Should().BeEquivalentTo(new[] { 1, 2 });
        }

        [Fact]
        public void Number_of_empty_cells_can_be_calculated_for_Matrix_with_single_empty_cell()
        {
            Matrix()
                .WithRow(new Cell(2), new Cell())
                .WithRow(new Cell(1), new Cell(2))
                .Build()
            .NumberOfEmptyCells
            .Should().Be(1);
        }

        [Fact]
        public void Number_of_empty_cells_can_be_calculated_for_Matrix_with_several_empty_cells()
        {
            Matrix()
                .WithRow(new Cell(), new Cell())
                .WithRow(new Cell(1), new Cell(2))
                .Build()
            .NumberOfEmptyCells
            .Should().Be(2);
        }
    }
}