using GildedRose.Console;

namespace GildedRose
{
    public class ConjuredItem(Item item) : ItemWrapper(item)
    {
        public override void UpdateQuality()
        {
            DecreaseQuality();
            DecreaseQuality();
        }

        public override void UpdateQualityAfterExpiration()
        {
            DecreaseQuality();
            DecreaseQuality();
        }
    }
}
