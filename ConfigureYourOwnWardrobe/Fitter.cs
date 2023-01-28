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

        public IEnumerable<Combination> HowManyCombinationsWouldFitExactly()
        {
            var combinations = new List<Combination>();

            foreach (WardrobeElement element in configuration.WardrobeElements)
            {
                if (element.FitsExactlyIn(availableSpaceInCm))
                {
                    combinations.Add(Combination.Of
                    (
                        new Part()
                        {
                            Element = element,
                            Quantity = availableSpaceInCm / element.SizeInCm,
                        }
                    ));

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

        private IEnumerable<Combination> CombinationsOfDifferentWardrobeElementsThatFitExactly(WardrobeElement first, WardrobeElement second)
        {
            var result = new List<Combination>();

            for (int numberOfFirst = 1; numberOfFirst <= configuration.WardrobeElements.Count; numberOfFirst++)
                for (int numberOfSecond = 1; numberOfSecond <= configuration.WardrobeElements.Count; numberOfSecond++)
                {
                    var estimate = first.SizeInCm * numberOfFirst + second.SizeInCm * numberOfSecond;

                    if (estimate == availableSpaceInCm)
                        result.Add(Combination.Of
                        (
                            new Part()
                            {
                                Element = first,
                                Quantity = numberOfFirst,
                            },
                            new Part()
                            {
                                Element = second,
                                Quantity = numberOfSecond,
                            }
                        ));
                }

            return result;
        }
    }
}