namespace SudokuKata.Tests
{
    public class Cell
    {
        public Cell(int? number)
        {
            Number = number;
        }

        public int? Number { get; }

        public override bool Equals(object? obj)
        {
            return obj is Cell cell && Number == cell.Number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Number);
        }

        public override string ToString()
        {
            return Number.HasValue ? Number.Value.ToString() : " ";
        }
    }
}