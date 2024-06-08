using GildedRose.Console;

namespace GildedRose
{
    public static class ItemExtensions
    {
        public static IEnumerable<ItemWrapper> Wrap(this IEnumerable<Item> items) =>
            items.Select<Item, ItemWrapper>(x =>
            {
                ItemWrapper item = new(x);

                if (item.IsAgedBrie())
                    return new AgedBrie(x);

                if (item.IsBackstagePasses())
                    return new BackstagePasses(x);

                if (item.IsConjured())
                    return new ConjuredItem(x);

                return new CommonItem(x);
            });
    }
}
