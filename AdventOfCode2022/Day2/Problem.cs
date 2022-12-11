using AdventOfCode2022.Tests;
using AdventOfCode2022.Utils;

namespace AdventOfCode2022.Day2
{
    public class Problem
    {
        public static int Solve()
        {
            var lines = FileReader.LinesOfProblemInput(path: "./Day2/Input.txt");

            var x = new StrategyGuide() { Recommendations = lines.ToArray() };

            return x.TournamentScore;
        }
    }
}