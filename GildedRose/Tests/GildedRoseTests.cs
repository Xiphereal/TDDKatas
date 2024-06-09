using FluentAssertions;
using GildedRose.Console;
using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseInventoryTests
    {
        private const string AgedBrie = "Aged Brie";
        private const int MinQuality = 0;
        private const int MaxQuality = 50;

        // Quality degrades afte reach day
        // SellIn is reduced after each day
        // Quality cannot go below 0
        // Quality cannot go above 50
        // Legendary Items do not degrade nor have sellIn
        // Aged Brie increases quality the older it gets
        // Once the sell by date has passed, Quality degrades twice as fast
        // What about Aged Brie when sell by date has passed????????
        // Backstage passes increases quality the older it gets
        // Backstage passes increases quality by 2 when 10 days remains
        // Backstage passes increases quality by 3 when 5 days remains
        // Backstage passes has quality drop to 0 when they are expired
        // Conjured items degrade in Quality twice as fast as normal items

        // Revisar ocurrencais del 0 para reemplazar por constante.

        [Fact]
        public void Characterization_1DayPasses()
        {
            List<Item> items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            Inventory sut = Inventory.With(items);

            sut.UpdateQuality();

            items.Should().BeEquivalentTo(
            [
                new Item {Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19},
                new Item {Name = "Aged Brie", SellIn = 1, Quality = 1},
                new Item {Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 14,
                        Quality = 21
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 2, Quality = 5}
            ]);
        }

        [Fact]
        public void Characterization_2DayPasses()
        {
            List<Item> items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            Inventory sut = Inventory.With(items);

            Repeat(sut.UpdateQuality, times: 2);

            items.Should().BeEquivalentTo(
            [
                new Item {Name = "+5 Dexterity Vest", SellIn = 8, Quality = 18},
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 2},
                new Item {Name = "Elixir of the Mongoose", SellIn = 3, Quality = 5},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 13,
                        Quality = 22
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 1, Quality = 4}
            ]);
        }

        private void Repeat(Action action, int times)
        {
            for (int i = 0; i < times; i++)
                action();
        }

        [Fact]
        public void Characterization_10DayPasses()
        {
            List<Item> items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            Inventory sut = Inventory.With(items);

            Repeat(sut.UpdateQuality, times: 10);

            items.Should().BeEquivalentTo(
            [
                new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10},
                new Item {Name = "Aged Brie", SellIn = -8, Quality = 18},
                new Item {Name = "Elixir of the Mongoose", SellIn = -5, Quality = 0},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 5,
                        Quality = 35
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = -7, Quality = 0}
            ]);
        }

        [Fact]
        public void QualityDegradesAfterEachDay()
        {
            Item item = new Item()
            {
                SellIn = 4,
                Quality = 1,
            };

            Inventory.With([item]).UpdateQuality();

            item.Quality.Should().Be(MinQuality);
        }

        [Fact]
        public void QualityNeverDropsBelow0()
        {
            Item item = new Item()
            {
                SellIn = 4,
                Quality = MinQuality,
            };
            Inventory sut = Inventory.With([item]);

            const int manyTimes = 100;
            Repeat(sut.UpdateQuality, manyTimes);

            item.Quality.Should().Be(MinQuality);
        }

        [Fact]
        public void QualityNeverGoesAbove50()
        {
            Item item = new Item()
            {
                Name = AgedBrie,
                SellIn = 4,
                Quality = MaxQuality,
            };
            Inventory sut = Inventory.With([item]);

            const int manyTimes = 100;
            Repeat(sut.UpdateQuality, manyTimes);

            item.Quality.Should().Be(MaxQuality);
        }
    }
}