namespace SudokuKata.Tests.UnitTests
{
    public class Sudoku
    {
        private Matrix initialGrid;

        public Sudoku(Matrix initialGrid)
        {
            if (initialGrid.IsSingleCell())
            {
                throw new ArgumentException("Single cell Sudokus make no sense");
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