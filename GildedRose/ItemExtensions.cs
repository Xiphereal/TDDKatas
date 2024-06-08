using GildedRose.Console;

namespace GildedRose
{
    public static class ItemExtensions
    {
        public static void ReduceSellInBy1(this Item item)
        {
            item.SellIn--;
        }
    }
}
