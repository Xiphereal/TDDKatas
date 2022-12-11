namespace AdventOfCode2022.Tests
{
    public class StrategyGuide
    {
        public Shape Opponent { get; set; }

        public Shape Recommendation => Opponent switch
        {
            Shape.Rock => Shape.Paper,
            Shape.Paper => Shape.Rock,
            Shape.Scissors => Shape.Scissors,
            _ => throw new InvalidOperationException("Invalid opponent play"),
        };
    }
}