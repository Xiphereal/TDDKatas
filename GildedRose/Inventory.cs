
namespace GildedRose.Console
{
    public class Inventory(IList<Item> items)
    {
        private const string AgedBrie = "Aged Brie";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const int MaxQuality = 50;

        public static Inventory With(IList<Item> items) => new Inventory(items);

        public void UpdateQuality()
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name != AgedBrie && items[i].Name != BackstagePasses)
                {
                    if (items[i].Quality > 0)
                    {
                        if (items[i].Name != Sulfuras)
                        {
                            items[i].Quality = items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (items[i].Quality < MaxQuality)
                    {
                        items[i].Quality = items[i].Quality + 1;

                        if (items[i].Name == BackstagePasses)
                        {
                            if (items[i].SellIn < 11)
                            {
                                if (items[i].Quality < MaxQuality)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }

                            if (items[i].SellIn < 6)
                            {
                                if (items[i].Quality < MaxQuality)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (items[i].Name != Sulfuras)
                {
                    items[i].SellIn = items[i].SellIn - 1;
                }

                if (items[i].SellIn < 0)
                {
                    if (items[i].Name != AgedBrie)
                    {
                        if (items[i].Name != BackstagePasses)
                        {
                            if (items[i].Quality > 0)
                            {
                                if (items[i].Name != Sulfuras)
                                {
                                    items[i].Quality = items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            items[i].Quality = items[i].Quality - items[i].Quality;
                        }
                    }
                    else
                    {
                        if (items[i].Quality < MaxQuality)
                        {
                            items[i].Quality = items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}