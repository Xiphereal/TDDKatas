namespace AdventOfCode2022.Day1.Model
{
    public class LinesToElfs
    {
        private readonly IEnumerable<string> lines;

        public LinesToElfs(IEnumerable<string> lines)
        {
            this.lines = lines;
        }

        public IEnumerable<Elf> Elfs
        {
            get
            {
                List<Elf> elfs = new();

                for (int i = 0; i < lines.Count(); i++)
                {
                    string line = lines.ElementAt(i);

                    if (IsTheCaloriesOfAFood(line))
                    {
                        List<int> elfCarriedFood = new()
                        {
                            int.Parse(line)
                        };

                        while (HasNext(i) && IsTheCaloriesOfAFood(lines.ElementAt(++i)))
                        {
                            elfCarriedFood.Add(int.Parse(lines.ElementAt(i)));
                        }

                        elfs.Add(new Elf(elfCarriedFood.ToArray()));
                    }
                }

                return elfs;

                bool HasNext(int i)
                {
                    return i < lines.Count() - 1;
                }

                static bool IsTheCaloriesOfAFood(string line)
                {
                    return int.TryParse(line, out _);
                }
            }
        }
    }
}