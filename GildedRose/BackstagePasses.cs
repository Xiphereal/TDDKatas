using GildedRose.Console;

namespace GildedRose
{
    public class BackstagePasses(Item item) : ItemWrapper(item)
    {
        public override void UpdateQuality()
        {
            IncreaseQuality();

            if (item.SellIn < 11)
                IncreaseQuality();

            if (item.SellIn < 6)
                IncreaseQuality();
        }

        public override void UpdateQualityAfterExpiration()
        {
            if (!IsExpired())
                throw new ArgumentException();

            RenderUseless();
        }

        private void RenderUseless() => item.Quality = 0;

    }
}
