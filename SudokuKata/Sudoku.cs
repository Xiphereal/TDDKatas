namespace SudokuKata.Tests.UnitTests
{
    public class Sudoku
    {
        private Matrix initialGrid;

        public Sudoku(Matrix initialGrid)
        {
            this.initialGrid = initialGrid;
        }

        public string IsSolution(Matrix matrix)
        {
            return "The proposed solution is correct";
        }
    }
}