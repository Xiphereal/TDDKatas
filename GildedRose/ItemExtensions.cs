using GildedRose.Console;
using static GildedRose.ItemWrapper;

namespace GildedRose
{
    public static class ItemExtensions
    {
        public static IEnumerable<ItemWrapper> Wrap(this IEnumerable<Item> items) =>
            items.Select<Item, ItemWrapper>(x =>
            {
                if (IsAgedBrie(x))
                    return new AgedBrie(x);

                if (IsBackstagePasses(x))
                    return new BackstagePasses(x);

                if (IsConjured(x))
                    return new ConjuredItem(x);

                return new CommonItem(x);
            });
    }
}
