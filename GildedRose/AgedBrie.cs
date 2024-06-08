using GildedRose.Console;

namespace GildedRose
{
    public class AgedBrie : ItemWrapper
    {
        public AgedBrie(Item item) : base(item)
        {
        }

        public override void UpdateQualityAfterExpiration()
        {
            if (!IsExpired())
                throw new ArgumentException();

            IncreaseQuality();
        }

        public override void UpdateQuality()
        {
            IncreaseQuality();
        }
    }
}
