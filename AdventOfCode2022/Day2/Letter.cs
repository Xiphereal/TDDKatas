namespace AdventOfCode2022.Tests
{
    public class Letter
    {
        private readonly string letter;

        public Letter(string letter)
        {
            if (letter != "A" && letter != "B" && letter != "C")
                throw new ArgumentException("The letter must be A, B or C");

            this.letter = letter;
        }

        public Shape ToShape()
        {
            return letter switch
            {
                "A" => Shape.Rock,
                "B" => Shape.Paper,
                "C" => Shape.Scissors,
                _ => throw new InvalidOperationException("The letter must be A, B or C"),
            };
        }
    }
}