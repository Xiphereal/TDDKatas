using AdventOfCode2022.Day1.Model;
using AdventOfCode2022.Utils;

namespace AdventOfCode2022.Day1
{
    public class Problem
    {
        public static int Solve()
        {
            var lines = FileReader.LinesOfProblemInput(path: "./Day1/Input.txt");

            var elfs = new LinesToElfs(lines).Elfs.ToArray();

            return new Expedition(elfs).SumOfCaloriesOfHighestCarrier;
        }
    }
}