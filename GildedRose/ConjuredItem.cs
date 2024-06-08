using GildedRose.Console;

namespace GildedRose
{
    public class ConjuredItem : ItemWrapper
    {
        public ConjuredItem(Item item) : base(item)
        {
        }

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
