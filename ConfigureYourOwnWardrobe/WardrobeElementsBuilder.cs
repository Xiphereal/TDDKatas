namespace ConfigureYourOwnWardrobe
{
    public class WardrobeElementsBuilder
    {
        private WardrobeElementsBuilder()
        {
        }

        public static WardrobeElementsBuilder WardrobeElements() => new();

        public int[] Of(params int[] sizesInCm)
        {
            return sizesInCm;
        }
    }
}