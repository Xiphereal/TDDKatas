using AdventOfCode2022.Day1.Model;
using AdventOfCode2022.Day1.Views;

namespace AdventOfCode2022.Day1
{
    public class Problem
    {
        public static int Solve()
        {
            var lines = new FileReader().LinesOfProblemInput();

            var elfs = new LinesToElfs(lines).Elfs.ToArray();

            return new Expedition(elfs).SumOfCaloriesOfHighestCarrier;
        }
    }
}