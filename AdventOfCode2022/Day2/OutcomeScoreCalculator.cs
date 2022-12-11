namespace AdventOfCode2022.Tests
{
    public class OutcomeScoreCalculator
    {
        public Outcome Outcome { get; set; }

        public int Score => Outcome switch
        {
            Outcome.Loss => 0,
            Outcome.Draw => 3,
            Outcome.Win => 6,
            _ => throw new InvalidOperationException("Invalid outcome"),
        };
    }
}