using GildedRose.Console;

namespace GildedRose
{
    public class GildedRoseInventory
    {
        public const string AgedBrieName = "Aged Brie";
        public const string SulfurasName = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePassesName = "Backstage passes to a TAFKAL80ETC concert";
        private const int ConjuredItemQualityDegradingRate = 2;

        public List<Item> Items { get; } = new List<Item>
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            new Item { Name = AgedBrieName, SellIn = 2, Quality = 0 },
            new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
            new Item { Name = SulfurasName, SellIn = 0, Quality = 80 },
            new Item
            {
                Name = BackstagePassesName,
                SellIn = 15,
                Quality = 20
            },
            new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        };

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];

                if (IsConjured(item))
                {
                    if (item.SellIn <= 0)
                    {
                        item.DegradeQualityBy(ConjuredItemQualityDegradingRate * 2);
                    }
                    else
                    {
                        item.DegradeQualityBy(ConjuredItemQualityDegradingRate);
                    }

                    continue;
                }

                if (Items[i].Name != AgedBrieName && Items[i].Name != BackstagePassesName)
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != SulfurasName)
                        {
                            Items[i].DegradeQualityBy(1);
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == BackstagePassesName)
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != SulfurasName)
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != AgedBrieName)
                    {
                        if (Items[i].Name != BackstagePassesName)
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != SulfurasName)
                                {
                                    Items[i].DegradeQualityBy(1);
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

        private static bool IsConjured(Item item)
        {
            string? name = item.Name?.ToLower();

            return name is not null && name.Contains("conjured");
        }
    }
}