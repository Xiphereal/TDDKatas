namespace AdventOfCode2022.Tests
{
    public class PlaySelector
    {
        public Shape ShouldPlay => Opponent switch
        {
            Shape.Rock => Shape.Paper,
            Shape.Paper => Shape.Scissors,
            Shape.Scissors => Shape.Rock,
            _ => throw new InvalidOperationException("Invalid opponent play"),
        };

        public Shape Opponent { get; set; }
    }
}