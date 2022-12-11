namespace AdventOfCode2022.Tests
{
    public class Scorer
    {
        public Play Winner { get; init; }

        public int Score => Winner switch
        {
            Play.Rock => 1,
            Play.Paper => 2,
            Play.Scissors => 3,
            _ => throw new InvalidOperationException("Invalid play"),
        };
    }
}