namespace SudokuKata.Tests
{
    public class CsvReader
    {
        public static Matrix Read(string path)
        {
            var matrix = new Matrix();

            foreach (string line in File.ReadAllLines(path))
            {
                var row = new List<int>();
                foreach (int number in line.Split(';').Select(x => int.Parse(x)))
                    row.Add(number);

                matrix.Rows.Add(row);
            }

            return matrix;
        }
    }
}