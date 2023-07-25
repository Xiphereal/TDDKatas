using System.Collections.Generic;
using System.Linq;

namespace SudokuKata.Tests.Builders
{
    public class MatrixBuilder
    {
        private readonly List<List<int>> rows = new List<List<int>>();

        private MatrixBuilder()
        { }

        public static MatrixBuilder Matrix() => new();

        public MatrixBuilder WithRow(params int[] numbers)
        {
            rows.Add(numbers.ToList());

            return this;
        }

        public Matrix Build()
        {
            return new Matrix() { Rows = rows };
        }
    }
}