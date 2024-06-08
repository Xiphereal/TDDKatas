using GildedRose.Console;

namespace GildedRose
{
    public abstract class ItemWrapper(Item item)
    {
        private const int MinQuality = 0;
        private const int MaxQuality = 50;

        private const string BackstagePases = "Backstage passes to a TAFKAL80ETC concert";
        private const string AgedBrie = "Aged Brie";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        protected Item item = item;

        public static bool IsAgedBrie(Item item) => item.Name == AgedBrie;
        public bool IsSulfuras() => item.Name == Sulfuras;
        public static bool IsBackstagePasses(Item item) => item.Name == BackstagePases;
        public static bool IsConjured(Item item) => item.Name.StartsWith("Conjured");

        public void ReduceSellInBy1() => item.SellIn--;

        public bool IsExpired() => item.SellIn < 0;

        public abstract void UpdateQuality();

        public void DecreaseQuality()
        {
            if (item.Quality > MinQuality)
                item.Quality--;
        }

        public void IncreaseQuality()
        {
            if (item.Quality < MaxQuality)
                item.Quality++;
        }

        public abstract void UpdateQualityAfterExpiration();
    }
}