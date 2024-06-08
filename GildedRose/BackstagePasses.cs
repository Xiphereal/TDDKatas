using GildedRose.Console;

namespace GildedRose
{
    public class BackstagePasses : ItemWrapper
    {
        public BackstagePasses(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            IncreaseQuality();

            if (item.SellIn < 11)
                IncreaseQuality();

            if (item.SellIn < 6)
                IncreaseQuality();
        }
    }
}
