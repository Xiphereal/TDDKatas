namespace ConfigureYourOwnWardrobe
{
    public class WardrobeElements
    {
        private readonly List<WardrobeElement> elements;

        public WardrobeElements(int[] sizesInCm)
        {
            elements = sizesInCm.Select(x => new WardrobeElement(x)).ToList();
        }

        internal List<WardrobeElement> Elements => elements;
    }
}