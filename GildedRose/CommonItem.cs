using GildedRose.Console;

namespace GildedRose
{
    public class CommonItem(Item item) : ItemWrapper(item)
    {
        public override void UpdateQuality() => DecreaseQuality();

        public override void UpdateQualityAfterExpiration()
        {
            if (!IsExpired())
                throw new ArgumentException();

            DecreaseQuality();
        }
    }
}
