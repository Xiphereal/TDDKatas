using GildedRose.Console;

namespace GildedRose
{
    public static class ItemExtensions
    {
        public static IEnumerable<ItemWrapper> Wrap(this IEnumerable<Item> items) =>
            items.Select(x => new ItemWrapper(x));
    }
}
