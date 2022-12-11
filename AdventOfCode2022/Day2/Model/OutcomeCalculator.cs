namespace AdventOfCode2022.Tests
{
    internal class OutcomeCalculator
    {
        public Shape Opponent { get; internal set; }
        public Shape Play { get; internal set; }

        public Outcome Outcome
        {
            get
            {
                if (Opponent == Play)
                    return Outcome.Draw;

                if (Opponent is Shape.Rock)
                {
                    if (Play is Shape.Paper)
                        return Outcome.Win;
                }

                if (Opponent is Shape.Scissors)
                {
                    if (Play is Shape.Rock)
                        return Outcome.Win;
                }

                if (Opponent is Shape.Paper)
                {
                    if (Play is Shape.Scissors)
                        return Outcome.Win;
                }

                return Outcome.Loss;
            }
        }
    }
}