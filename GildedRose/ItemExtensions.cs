using GildedRose.Console;

namespace GildedRose
{
    public static class ItemExtensions
    {
        private const int MinQuality = 0;
        private const int MaxQuality = 50;

        private const string BackstagePases = "Backstage passes to a TAFKAL80ETC concert";
        private const string AgedBrie = "Aged Brie";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        public static bool IsCommon(this Item item) =>
            item.Name != AgedBrie && item.Name != BackstagePases;

        public static void ReduceSellInBy1(this Item item) => item.SellIn--;

        public static bool IsExpired(this Item item) => item.SellIn < 0;

        public static void DecreaseQuality(this Item item)
        {
            if (item.Quality > MinQuality)
                item.Quality--;
        }

        public static void IncreaseQuality(this Item item)
        {
            if (item.Quality < MaxQuality)
                item.Quality++;
        }

        public static void UpdateQualityAfterExpiration(this Item item)
        {
            if (!item.IsExpired())
                throw new ArgumentException();

            if (item.IsAgedBrie())
                item.IncreaseQuality();
            else if (item.IsBackstagePasses())
                item.RenderUseless();
            else
                item.DecreaseQuality();
        }

        public static bool IsAgedBrie(this Item item) => item.Name == AgedBrie;
        public static bool IsSulfuras(this Item item) => item.Name == Sulfuras;

        public static void RenderUseless(this Item item) => item.Quality = 0;

        public static bool IsBackstagePasses(this Item item) =>
            item.Name == BackstagePases;

        public static void IncreaseQualityForBackstagePasses(this Item item)
        {
            if (!IsBackstagePasses(item))
                throw new ArgumentException();

            item.IncreaseQuality();

            if (item.SellIn < 11)
                item.IncreaseQuality();

            if (item.SellIn < 6)
                item.IncreaseQuality();
        }
    }
}
