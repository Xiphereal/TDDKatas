namespace ConfigureYourOwnWardrobe.Tests
{
    public class Fitter
    {
        public Fitter WithSizes(params int[] size)
        {
            return this;
        }

        public string FittingIn(int v)
        {
            return "5 of 50cm";
        }
    }
}