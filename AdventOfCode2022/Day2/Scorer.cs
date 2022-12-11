namespace AdventOfCode2022.Tests
{
    public class PlayScoreCalculator
    {
        public Shape Play { get; init; }

        public int Score => Play switch
        {
            Shape.Rock => 1,
            Shape.Paper => 2,
            Shape.Scissors => 3,
            _ => throw new InvalidOperationException("Invalid play"),
        };
    }
}