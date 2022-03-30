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
            foreach (Item item in Items)
            {
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

                if (item.Name == AgedBrieName)
                {
                    item.IncreaseQualityBy(1);

                    item.UpdateDaysToSell();

                    if (item.SellIn < 0)
                    {
                        item.IncreaseQualityBy(1);
                    }

                    continue;
                }

                if (item.Name != BackstagePassesName)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != SulfurasName)
                        {
                            item.DegradeQualityBy(1);
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == BackstagePassesName)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                item.UpdateDaysToSell();

                if (item.SellIn < 0)
                {
                    if (item.Name == BackstagePassesName)
                    {
                        item.Quality = 0;
                    }
                    else
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != SulfurasName)
                            {
                                item.DegradeQualityBy(1);
                            }
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