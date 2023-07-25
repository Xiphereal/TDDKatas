namespace SudokuKata.Tests
{
    public class Matrix
    {
        public List<List<Cell>> Rows { get; set; } = new List<List<Cell>>();
        public List<List<Cell>> Columns => ColumnsFrom(Rows);

        private List<List<Cell>> ColumnsFrom(List<List<Cell>> rows)
        {
            if (Rows.Any(r => r.Count != Rows.Count))
            {
                throw new ArgumentException("Matrix must be squared (NxN)");
            }

            var columns = new List<List<Cell>>();
            for (int i = 0; i < rows.Count; i++)
            {
                var column = new List<Cell>();
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
            if (Rows.Any(r => r.Count != Rows.Count))
            {
                throw new ArgumentException("Matrix must be squared (NxN)");
            }

            if (Rows.Any(r => HasDuplicates(r)) || Columns.Any(r => HasDuplicates(r)))
                return "The input doesn't comply with Sudoku's rules.";

            return "The input complies with Sudoku's rules.";

            static bool HasDuplicates(List<Cell> row)
            {
                return row.Distinct().Count() != row.Count;
            }
        }
    }
}