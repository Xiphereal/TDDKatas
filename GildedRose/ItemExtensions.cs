using GildedRose.Console;

namespace GildedRose
{
    public static class ItemExtensions
    {
        private const int MinQuality = 0;

        public static void ReduceSellInBy1(this Item item)
        {
            item.SellIn--;
        }

        public static void DecreaseQuality(this Item item)
        {
            if (item.Quality > MinQuality)
                item.Quality--;
        }
    }
}
