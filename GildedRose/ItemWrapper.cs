using GildedRose.Console;

namespace GildedRose
{
    public class ItemWrapper
    {
        private const int MinQuality = 0;
        private const int MaxQuality = 50;

        private const string BackstagePases = "Backstage passes to a TAFKAL80ETC concert";
        private const string AgedBrie = "Aged Brie";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        protected Item item;

        public ItemWrapper(Item item)
        {
            this.item = item;
        }

        public bool IsAgedBrie() => item.Name == AgedBrie;
        public bool IsSulfuras() => item.Name == Sulfuras;
        public bool IsBackstagePasses() => item.Name == BackstagePases;
        public bool IsConjured() => item.Name.StartsWith("Conjured");

        public void ReduceSellInBy1() => item.SellIn--;

        public bool IsExpired() => item.SellIn < 0;

        public virtual void UpdateQuality()
        {
        }

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

        public virtual void UpdateQualityAfterExpiration()
        {

        }
    }
}