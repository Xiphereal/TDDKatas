namespace AdventOfCode2022.Day1.Model
{
    public class Elf
    {
        public Elf(params int[] carriedFood)
        {
            CarriedFood = carriedFood;
        }

        public IEnumerable<int> CarriedFood { get; init; } = new List<int>();
    }
}