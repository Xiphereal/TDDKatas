﻿namespace SudokuKata.Tests.UnitTests
{
    public class Sudoku
    {
        private Matrix initialGrid;

        public Sudoku(Matrix initialGrid)
        {
            if (initialGrid.Rows.Count() is 0)
            {
                throw new ArgumentException("Sudokus with no cells make no sense");
            }

            if (initialGrid.IsSingleCell())
            {
                throw new ArgumentException("Single cell Sudokus make no sense");
            }

            if (!initialGrid.Rows.Any(r => r.Any(c => c is EmptyCell)))
            {
                throw new ArgumentException("Initial grid must have empty cells");
            }

            this.initialGrid = initialGrid;
        }

        public string IsSolution(Matrix proposal)
        {
            if (proposal.DoesNotComplyWithRules() || !proposal.AllNumbersCorrelateWith(initialGrid))
                return "The proposed solution is incorrect";

            return "The proposed solution is correct";
        }
    }
}