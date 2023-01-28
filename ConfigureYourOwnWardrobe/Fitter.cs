namespace ConfigureYourOwnWardrobe
{
    public class Fitter
    {
        private readonly int availableSpaceInCm;
        private Configuration configuration;

        private Fitter(int availableSpaceInCm)
        {
            this.availableSpaceInCm = availableSpaceInCm;
        }

        public static Fitter WithAnSpaceOf(int availableSpaceInCm) => new(availableSpaceInCm);

        public Fitter AndAConfigurationOf(params int[] sizesInCm)
        {
            configuration = new Configuration(sizesInCm);

            return this;
        }

        public IEnumerable<string> HowManyCombinationsWouldFitExactly()
        {
            var combinations = new List<string>();

            foreach (WardrobeElement element in configuration.WardrobeElements)
            {
                if (element.FitsExactlyIn(availableSpaceInCm))
                {
                    combinations.Add($"{availableSpaceInCm / element.SizeInCm} of {element.SizeInCm}cm");

                    continue;
                }

                for (int i = 0; i < configuration.WardrobeElements.Count; i++)
                {
                    var other = configuration.WardrobeElements[i];

                    if (other.Equals(element))
                        continue;

                    combinations.AddRange(CombinationsOfDifferentWardrobeElementsThatFitExactly(element, other));
                }
            }

            return combinations;
        }

        private IEnumerable<string> CombinationsOfDifferentWardrobeElementsThatFitExactly(WardrobeElement first, WardrobeElement second)
        {
            var result = new List<string>();

            for (int numberOfFirst = 1; numberOfFirst <= configuration.WardrobeElements.Count; numberOfFirst++)
                for (int numberOfSecond = 1; numberOfSecond <= configuration.WardrobeElements.Count; numberOfSecond++)
                {
                    var estimate = first.SizeInCm * numberOfFirst + second.SizeInCm * numberOfSecond;

                    if (estimate == availableSpaceInCm)
                        result.Add($"{numberOfFirst} of {first.SizeInCm}cm and {numberOfSecond} of {second.SizeInCm}cm");
                }

            return result;
        }
    }
}