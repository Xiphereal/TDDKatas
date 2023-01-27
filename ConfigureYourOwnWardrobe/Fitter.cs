namespace ConfigureYourOwnWardrobe
{
    public class Fitter
    {
        private int sizeInCm;

        public Fitter WithConfigurationOf(params int[] sizesInCm)
        {
            sizeInCm = sizesInCm.First();

            return this;
        }

        public string FittingIn(int availableSizeInCm)
        {
            return $"{availableSizeInCm / sizeInCm} of {sizeInCm}cm";
        }
    }
}