using GildedRose.Console;

namespace GildedRose
{
    public static class ItemExtensions
    {
        public static IEnumerable<ItemWrapper> Wrap(this IEnumerable<Item> items) =>
            items.Select(x =>
            {
                ItemWrapper item = new ItemWrapper(x);

                if (item.IsAgedBrie())
                    return new AgedBrie(x);

                return item;
            });
    }
}
