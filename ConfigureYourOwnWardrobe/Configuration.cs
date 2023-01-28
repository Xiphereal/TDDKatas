namespace ConfigureYourOwnWardrobe
{
    internal class Configuration
    {
        public Configuration(int[] sizesInCm)
        {
            WardrobeElements = new WardrobeElements(sizesInCm).Elements;
        }

        public List<WardrobeElement> WardrobeElements { get; }
    }
}