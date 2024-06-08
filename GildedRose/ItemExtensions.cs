using GildedRose.Console;

namespace GildedRose
{
    public static class ItemExtensions
    {
        private const int MinQuality = 0;
        private const int MaxQuality = 50;

        private const string BackstagePases = "Backstage passes to a TAFKAL80ETC concert";

        public static void ReduceSellInBy1(this Item item)
        {
            item.SellIn--;
        }

        public static void DecreaseQuality(this Item item)
        {
            if (item.Quality > MinQuality)
                item.Quality--;
        }

        public static void IncreaseQuality(this Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality++;

                if (item.IsBackstagePasses())
                    item.IncreaseQualityForBackstagePasses();
            }
        }

        public static bool IsBackstagePasses(this Item item)
        {
            return item.Name == BackstagePases;
        }

        public static void IncreaseQualityForBackstagePasses(this Item item)
        {
            if (!IsBackstagePasses(item))
            {
                throw new ArgumentException();
            }

            if (item.SellIn < 11)
            {
                if (item.Quality < MaxQuality)
                {
                    item.Quality++;
                }
            }

            if (item.SellIn < 6)
            {
                if (item.Quality < MaxQuality)
                {
                    item.Quality++;
                }
            }
        }
    }
}
