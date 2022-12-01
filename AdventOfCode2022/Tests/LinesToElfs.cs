using AdventOfCode2022.Day1.Model;
using System.Collections.Generic;

namespace AdventOfCode2022.Tests
{
    internal class LinesToElfs
    {
        private readonly List<string> lines;

        public LinesToElfs(List<string> lines)
        {
            this.lines = lines;
        }

        public IEnumerable<Elf> Elfs
        {
            get
            {
                List<Elf> elfs = new();

                for (int i = 0; i < lines.Count; i++)
                {
                    string line = lines[i];

                    if (IsTheCaloriesOfAFood(line))
                    {
                        List<int> elfCarriedFood = new()
                        {
                            int.Parse(line)
                        };

                        while (HasNext(i) && IsTheCaloriesOfAFood(lines[++i]))
                        {
                            elfCarriedFood.Add(int.Parse(lines[i]));
                        }

                        elfs.Add(new Elf(elfCarriedFood.ToArray()));
                    }
                }

                return elfs;

                bool HasNext(int i)
                {
                    return i < lines.Count - 1;
                }

                static bool IsTheCaloriesOfAFood(string line)
                {
                    return int.TryParse(line, out _);
                }
            }
        }
    }
}