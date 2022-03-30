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

        public static void IncreaseQualityBy(this Item item, int increment)
        {
            if (item.Quality + increment < 50)
            {
                item.Quality += increment;
            }
        }

        public static void UpdateDaysToSell(this Item item)
        {
            if (item.Name == GildedRoseInventory.SulfurasName)
            {
                return;
            }

            item.SellIn--;
        }
    }
}