namespace AdventOfCode2022.Tests
{
    public class PlaySelector
    {
        public Play Me => Opponent switch
        {
            Play.Rock => Play.Paper,
            Play.Paper => Play.Scissors,
            Play.Scissors => Play.Rock,
            _ => throw new InvalidOperationException("Invalid opponent play"),
        };

        public Play Opponent { get; set; }
    }
}