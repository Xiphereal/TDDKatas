namespace ConfigureYourOwnWardrobe
{
    public class WardrobeElement
    {
        public WardrobeElement(int sizeInCm)
        {
            SizeInCm = sizeInCm;
        }

        public int SizeInCm { get; }

        public bool FitsExactlyIn(int availableSpaceInCm)
        {
            return availableSpaceInCm % SizeInCm == 0;
        }
    }
}