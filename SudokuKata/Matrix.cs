using System.Text;

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
            if (!DoesComplyWithRules())
                return "The input doesn't comply with Sudoku's rules.";

            return "The input complies with Sudoku's rules.";
        }

        public bool DoesComplyWithRules()
        {
            if (Rows.Any(r => r.Count != Rows.Count))
            {
                throw new ArgumentException("Matrix must be squared (NxN)");
            }

            return !Rows.Any(r => HasDuplicates(r)) && !Columns.Any(r => HasDuplicates(r));

            static bool HasDuplicates(List<Cell> row)
            {
                return row.Distinct().Count() != row.Count;
            }
        }

        public bool AllNumbersCorrelateWith(Matrix initialGrid)
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                List<Cell> row = Rows[i];
                for (int j = 0; j < row.Count; j++)
                {
                    Cell cell = row[j];

                    if (cell.IsEmpty() || initialGrid.Rows[i][j].IsEmpty())
                        continue;

                    if (cell.Number != initialGrid.Rows[i][j].Number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsSingleCell()
        {
            return Rows.Count == 1 && Columns.Count == 1;
        }

        public bool ContainsAnyEmptyCell()
        {
            return Rows.Any(r => r.Any(c => c.IsEmpty()));
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var row in Rows)
            {
                foreach (var cell in row)
                {
                    builder.Append($"{cell.Number},");
                }

                if (!Rows.Last().Equals(row))
                    builder.AppendLine();
            }

            return builder.ToString();
        }

        public Matrix DeepClone()
        {
            var clone = new Matrix();

            foreach (var row in Rows)
            {
                var clonedRow = new List<Cell>();

                foreach (var cell in row)
                    clonedRow.Add(new Cell(cell.Number));

                clone.Rows.Add(clonedRow);
            }

            return clone;
        }
    }
}