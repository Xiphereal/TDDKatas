using System.Collections.Generic;
using System.Linq;

namespace SudokuKata.Tests.Builders
{
    public class MatrixBuilder
    {
        private readonly List<List<Cell>> rows = new List<List<Cell>>();

        private MatrixBuilder()
        { }

        public static MatrixBuilder Matrix() => new();

        public MatrixBuilder WithRow(params int[] numbers)
        {
            rows.Add(numbers.Select(n => new Cell(n)).ToList());

            return this;
        }

        public MatrixBuilder WithRow(params Cell[] cells)
        {
            rows.Add(cells.ToList());

            return this;
        }

        public Matrix Build()
        {
            return new Matrix() { Rows = rows };
        }
    }
}