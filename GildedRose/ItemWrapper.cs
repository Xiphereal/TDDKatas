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

        private Item item;

        public ItemWrapper(Item item)
        {
            this.item = item;
        }

        public bool IsCommon() =>
            item.Name != AgedBrie && item.Name != BackstagePases;

        public void ReduceSellInBy1() => item.SellIn--;
        public bool IsExpired() => item.SellIn < 0;

        public virtual void UpdateQuality()
        {
            DecreaseQuality();
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
            if (!IsExpired())
                throw new ArgumentException();

            if (IsBackstagePasses())
                RenderUseless();
            else
                DecreaseQuality();
        }

        public bool IsAgedBrie() => item.Name == AgedBrie;
        public bool IsSulfuras() => item.Name == Sulfuras;

        public void RenderUseless() => item.Quality = 0;

        public bool IsBackstagePasses() =>
            item.Name == BackstagePases;

        public void IncreaseQualityForBackstagePasses()
        {
            if (!IsBackstagePasses())
                throw new ArgumentException();

            IncreaseQuality();

            if (item.SellIn < 11)
                IncreaseQuality();

            if (item.SellIn < 6)
                IncreaseQuality();
        }
    }
}