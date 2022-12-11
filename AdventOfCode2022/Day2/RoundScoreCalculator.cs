namespace AdventOfCode2022.Tests
{
    public class RoundScoreCalculator
    {
        public Shape Play { get; set; }
        public Outcome Outcome { get; set; }
        public int Score
        {
            get
            {
                var playScoreCalculator = new PlayScoreCalculator()
                {
                    Play = Play,
                };

                var outcomeScoreCalculator = new OutcomeScoreCalculator()
                {
                    Outcome = Outcome,
                };

                return playScoreCalculator.Score + outcomeScoreCalculator.Score;
            }
        }
    }
}