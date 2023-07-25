namespace SudokuKata.Tests
{
    public class Matrix
    {
        public List<List<int>> Rows { get; set; } = new List<List<int>>();

        public string CheckForViolations()
        {
            if (Rows.Any(r => HasDuplicates(r)))
                return "The input doesn't comply with Sudoku's rules.";

            return "The input complies with Sudoku's rules.";

            static bool HasDuplicates(List<int> row)
            {
                return row.Distinct().Count() != row.Count;
            }
        }
    }
}