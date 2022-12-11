namespace AdventOfCode2022.Tests
{
    public class Letter
    {
        private readonly string letter;

        public Letter(string letter)
        {
            if (letter != "A" && letter != "B" && letter != "C"
                && letter != "Y" && letter != "X" && letter != "Z")
                throw new ArgumentException("The letter must be {A, B, C, Y, X, Z}");

            this.letter = letter;
        }

        public Shape ToShape()
        {
            return letter switch
            {
                "A" or "Y" => Shape.Rock,
                "B" or "X" => Shape.Paper,
                "C" or "Z" => Shape.Scissors,
                _ => throw new InvalidOperationException("The letter must be {A, B, C, Y, X, Z}"),
            };
        }
    }
}