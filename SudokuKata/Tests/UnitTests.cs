﻿using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace SudokuKata.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Compliant_matrix()
        {
            var matrix = new Matrix();
            matrix.Rows.Add(new List<int> { 1, 2 });
            matrix.Rows.Add(new List<int> { 2, 1 });

            matrix.CheckForViolations().Should().Be("The input complies with Sudoku's rules.");
        }

        [Fact]
        public void Matrix_with_duplicated_numbers_in_row_is_noncompliant()
        {
            var matrix = new Matrix();
            matrix.Rows.Add(new List<int> { 1, 1 });
            matrix.Rows.Add(new List<int> { 2, 2 });

            matrix.CheckForViolations().Should().Be("The input doesn't comply with Sudoku's rules.");
        }
    }
}