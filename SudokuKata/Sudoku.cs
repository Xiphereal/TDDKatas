namespace SudokuKata.Tests.UnitTests
{
    public class Sudoku
    {
        private Matrix initialGrid;

        public Sudoku(Matrix initialGrid)
        {
            this.initialGrid = initialGrid;
        }

        public string IsSolution(Matrix proposal)
        {
            if (proposal.DoesNotComplyWithRules())
                return "The proposed solution is incorrect";

            return "The proposed solution is correct";
        }
    }
}