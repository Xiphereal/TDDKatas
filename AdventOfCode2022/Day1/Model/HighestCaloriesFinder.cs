namespace AdventOfCode2022.Day1.Model
{
    internal class HighestCaloriesFinder
    {
        public static Elf Find(params Elf[] elfs)
        {
            return elfs.OrderByDescending(e => e.CarriedFood.Sum()).First();
        }
    }
}