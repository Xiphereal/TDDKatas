namespace AdventOfCode2022.Tests
{
    public class Tournament
    {
        public List<int> RoundsScores { get; init; } = new();

        public int Score => RoundsScores.Sum();
    }
}