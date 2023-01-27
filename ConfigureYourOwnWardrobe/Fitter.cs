namespace ConfigureYourOwnWardrobe
{
    public class Fitter
    {
        private int availableSpaceInCm;
        private int elementSizeInCm;

        private Fitter(int availableSpaceInCm)
        {
            this.availableSpaceInCm = availableSpaceInCm;
        }

        public static Fitter WithAnSpaceOf(int availableSpaceInCm) => new(availableSpaceInCm);

        public Fitter AndAConfigurationOf(params int[] sizesInCm)
        {
            elementSizeInCm = sizesInCm.First();

            return this;
        }

        public string HowManyWouldFit()
        {
            return $"{availableSpaceInCm / elementSizeInCm} of {elementSizeInCm}cm";
        }
    }
}