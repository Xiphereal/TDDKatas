namespace SudokuKata.Tests
{
    public class Matrix
    {
        public List<List<int>> Rows { get; set; } = new List<List<int>>();
        public List<List<int>> Columns => ColumnsFrom(Rows);

        private List<List<int>> ColumnsFrom(List<List<int>> rows)
        {
            var columns = new List<List<int>>();
            for (int i = 0; i < rows.Count; i++)
            {
                var column = new List<int>();
                for (int j = 0; j < rows.Count; j++)
                {
                    column.Add(rows[j][i]);
                }

                columns.Add(column);
            }

            return columns;
        }

        public string CheckForViolations()
        {
            if (Rows.Any(r => HasDuplicates(r)) || Columns.Any(r => HasDuplicates(r)))
                return "The input doesn't comply with Sudoku's rules.";

            return "The input complies with Sudoku's rules.";

            static bool HasDuplicates(List<int> row)
            {
                return row.Distinct().Count() != row.Count;
            }
        }
    }
}