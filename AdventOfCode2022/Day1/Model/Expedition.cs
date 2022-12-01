namespace AdventOfCode2022.Day1.Model
{
    public class Expedition
    {
        private readonly Elf[] elf;

        public Expedition(params Elf[] elf)
        {
            this.elf = elf;
        }

        private Elf HighestCaloriesCarrier => HighestCaloriesFinder.Find(elf);

        public int SumOfCaloriesOfHighestCarrier => HighestCaloriesCarrier.CarriedFood.Sum();
    }
}