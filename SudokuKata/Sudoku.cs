namespace SudokuKata.Tests.UnitTests
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