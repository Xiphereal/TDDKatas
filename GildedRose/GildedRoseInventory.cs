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
                switch (item.Name)
                {
                    case SulfurasName:
                        break;

                    case AgedBrieName:
                        UpdateAgedBrieQuality(item);

                        break;

                    case BackstagePassesName:
                        UpdateBackstagePassesQuality(item);

                        break;

                    default:
                        if (item.IsConjured())
                        {
                            UpdateConjuredItemQuality(item);
                        }
                        else
                        {
                            UpdateNormalItemQuality(item);
                        }

                        break;
                }

                item.UpdateDaysToSell();
            }
        }

        private static void UpdateAgedBrieQuality(Item item)
        {
            if (item.HasSellDayPassedOrIsDueToday())
            {
                item.IncreaseQualityBy(2);
            }
            else
            {
                item.IncreaseQualityBy(1);
            }
        }

        private static void UpdateBackstagePassesQuality(Item item)
        {
            if (item.SellIn < 6)
            {
                item.IncreaseQualityBy(3);
            }
            else if (item.SellIn < 11)
            {
                item.IncreaseQualityBy(2);
            }
            else
            {
                item.IncreaseQualityBy(1);
            }

            if (item.HasSellDayPassedOrIsDueToday())
            {
                item.Quality = 0;
            }
        }

        private static void UpdateConjuredItemQuality(Item item)
        {
            if (item.HasSellDayPassedOrIsDueToday())
            {
                item.DegradeQualityBy(ConjuredItemQualityDegradingRate * 2);
            }
            else
            {
                item.DegradeQualityBy(ConjuredItemQualityDegradingRate);
            }
        }

        private static void UpdateNormalItemQuality(Item item)
        {
            if (item.HasSellDayPassedOrIsDueToday())
            {
                item.DegradeQualityBy(2);
            }
            else
            {
                item.DegradeQualityBy(1);
            }
        }
    }
}