namespace AdventOfCode2022.Tests
{
    public class StrategyGuide
    {
        public string[] Recommendations { private get; init; }

        public int TournamentScore
        {
            get
            {
                var tournament = new Tournament();

                foreach (string recommendation in Recommendations)
                {
                    Shape opponent = new Letter(recommendation.Split(' ').First()).ToShape();
                    Shape play = new Letter(recommendation.Split(' ').Last()).ToShape();

                    var outcomeCalculator = new OutcomeCalculator()
                    {
                        Opponent = opponent,
                        Play = play,
                    };

                    var roundScoreCalculator = new RoundScoreCalculator()
                    {
                        Play = play,
                        Outcome = outcomeCalculator.Outcome
                    };

                    tournament.RoundsScores.Add(roundScoreCalculator.Score);
                }

                return tournament.Score;
            }
        }
    }
}