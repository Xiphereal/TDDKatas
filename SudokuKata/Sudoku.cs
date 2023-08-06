namespace SudokuKata.Tests.UnitTests
{
    public class Sudoku
    {
        private Matrix initialGrid;

        public Sudoku(Matrix initialGrid)
        {
            if (initialGrid.Rows.Count is 0)
            {
                throw new ArgumentException("Sudokus with no cells make no sense");
            }

            if (initialGrid.IsSingleCell())
            {
                throw new ArgumentException("Single cell Sudokus make no sense");
            }

            if (!initialGrid.Rows.Any(r => r.Any(c => c.IsEmpty())))
            {
                throw new ArgumentException("Initial grid must have empty cells");
            }

            this.initialGrid = initialGrid;
        }

        public string IsSolution(Matrix proposal)
        {
            if (!proposal.DoesComplyWithRules()
                || !proposal.AllNumbersCorrelateWith(initialGrid)
                || proposal.ContainsAnyEmptyCell())
                return "The proposed solution is incorrect";

            return "The proposed solution is correct";
        }

        public string ProposeSolution()
        {
            if (!initialGrid.DoesComplyWithRules())
                return "The Sudoku is not solvable";

            var candidate = initialGrid.DeepClone();

            var attemps = 0;
            const int maxAllowedAttemps = 20;

            do
            {
                candidate = initialGrid.DeepClone();

                foreach (var row in candidate.Rows)
                {
                    foreach (var cell in row.Where(c => c.IsEmpty()))
                    {
                        IEnumerable<int> availableNumbers =
                            candidate.AvailableCandidateNumbersIn(
                                candidate.Rows.IndexOf(row));

                        cell.Number =
                            availableNumbers
                                .ElementAt(
                                    new Random().Next(0, availableNumbers.Count()));
                    }
                }

                attemps++;
            }
            while (
                IsSolution(candidate) == "The proposed solution is incorrect"
                    && attemps < maxAllowedAttemps);

            return IsSolution(candidate) == "The proposed solution is incorrect"
                ? "The Sudoku is not solvable"
                : candidate.ToString();
        }
    }
}