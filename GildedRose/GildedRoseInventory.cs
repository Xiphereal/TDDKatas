﻿using GildedRose.Console;

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
                if (item.Name == SulfurasName)
                {
                    continue;
                }

                if (item.Name == AgedBrieName)
                {
                    UpdateAgedBrieQuality(item);

                    continue;
                }

                if (item.Name == BackstagePassesName)
                {
                    UpdateBackstagePassesQuality(item);

                    continue;
                }

                if (item.IsConjured())
                {
                    UpdateConjuredItemQuality(item);

                    continue;
                }

                UpdateNormalItem(item);
            }
        }

        private static void UpdateAgedBrieQuality(Item item)
        {
            item.IncreaseQualityBy(1);

            item.UpdateDaysToSell();

            if (item.SellIn < 0)
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

            item.UpdateDaysToSell();

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

        private static void UpdateConjuredItemQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.DegradeQualityBy(ConjuredItemQualityDegradingRate * 2);
            }
            else
            {
                item.DegradeQualityBy(ConjuredItemQualityDegradingRate);
            }
        }

        private static void UpdateNormalItem(Item item)
        {
            item.DegradeQualityBy(1);

            item.UpdateDaysToSell();

            if (item.SellIn < 0)
            {
                item.DegradeQualityBy(1);
            }
        }
    }
}