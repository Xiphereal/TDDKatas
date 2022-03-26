namespace GildedRose.Console
{
    internal static class ItemExtensions
    {
        public static void DegradeQualityBy(this Item item, int decrement)
        {
            if (item.Quality - decrement < 0)
            {
                return;
            }

            item.Quality -= decrement;
        }
    }
}