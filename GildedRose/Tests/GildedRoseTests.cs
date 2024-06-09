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
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";


        private const int MinQuality = 0;
        private const int MaxQuality = 50;

        // Conjured items degrade in Quality twice as fast as normal items

        // Revisar ocurrencais del 0 para reemplazar por constante.

        [Fact]
        public void Characterization_1DayPasses()
        {
            List<Item> items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                Sulfuras(),
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            Inventory sut = Inventory.With(items);

            sut.PassDay();

            items.Should().BeEquivalentTo(
            [
                new Item {Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19},
                new Item {Name = AgedBrie, SellIn = 1, Quality = 1},
                new Item {Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6},
                Sulfuras(),
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
                new Item {Name = AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                Sulfuras(),
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            Inventory sut = Inventory.With(items);

            Repeat(sut.PassDay, times: 2);

            items.Should().BeEquivalentTo(
            [
                new Item {Name = "+5 Dexterity Vest", SellIn = 8, Quality = 18},
                new Item {Name = AgedBrie, SellIn = 0, Quality = 2},
                new Item {Name = "Elixir of the Mongoose", SellIn = 3, Quality = 5},
                Sulfuras(),
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
                new Item {Name = AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                Sulfuras(),
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
            Inventory sut = Inventory.With(items);

            Repeat(sut.PassDay, times: 10);

            items.Should().BeEquivalentTo(
            [
                new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10},
                new Item {Name = AgedBrie, SellIn = -8, Quality = 18},
                new Item {Name = "Elixir of the Mongoose", SellIn = -5, Quality = 0},
                Sulfuras(),
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
        public void BothQualityAndSellIn_DegradesAfterEachDay()
        {
            Item item = new Item()
            {
                SellIn = 4,
                Quality = 1,
            };

            Inventory.With([item]).PassDay();

            item.SellIn.Should().Be(3);
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
            Repeat(sut.PassDay, manyTimes);

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
            Repeat(sut.PassDay, manyTimes);

            item.Quality.Should().Be(MaxQuality);
        }

        [Fact]
        public void AgedBrie_IncreasesQualityAsItGetsOlder()
        {
            Item item = new Item()
            {
                Name = AgedBrie,
                SellIn = 4,
                Quality = 10,
            };
            Inventory sut = Inventory.With([item]);

            sut.PassDay();

            item.Quality.Should().Be(11);
        }

        [Fact]
        public void LegendaryItems_DoNotHaveTheirQualityNorSellInUpdated()
        {
            Item item = Sulfuras();
            Inventory sut = Inventory.With([item]);

            sut.PassDay();

            item.Quality.Should().Be(Sulfuras().Quality);
            item.SellIn.Should().Be(Sulfuras().SellIn);
        }

        [Fact]
        public void QualityDegradesTwiceAsFast_AfterExpiration()
        {
            Item item = new Item()
            {
                SellIn = 0,
                Quality = 2,
            };

            Inventory.With([item]).PassDay();

            item.Quality.Should().Be(MinQuality);
        }

        [Fact]
        public void AgedBrie_IncreasesQualityTwiceAsFast_AfterExpiration()
        {
            Item item = new Item()
            {
                Name = AgedBrie,
                SellIn = 0,
                Quality = 10,
            };
            Inventory sut = Inventory.With([item]);

            sut.PassDay();

            item.Quality.Should().Be(12);
        }

        [Fact]
        public void BackstagePasses_IncreasesQualityBy1_WhenThereAreMoreThan10DaysRemaining()
        {
            Item item = new Item()
            {
                Name = BackstagePasses,
                SellIn = 11,
                Quality = 5,
            };
            Inventory sut = Inventory.With([item]);

            sut.PassDay();

            item.Quality.Should().Be(6);
        }

        [Fact]
        public void BackstagePasses_IncreasesQualityBy2_WhenThereAre10DaysRemaining()
        {
            Item item = new Item()
            {
                Name = BackstagePasses,
                SellIn = 10,
                Quality = 5,
            };
            Inventory sut = Inventory.With([item]);

            sut.PassDay();

            item.Quality.Should().Be(7);
        }

        [Fact]
        public void BackstagePasses_IncreasesQualityBy3_WhenThereAre5DaysRemaining()
        {
            Item item = new Item()
            {
                Name = BackstagePasses,
                SellIn = 5,
                Quality = 7,
            };
            Inventory sut = Inventory.With([item]);

            sut.PassDay();

            item.Quality.Should().Be(10);
        }

        [Fact]
        public void BackstagePasses_AreUselessWhenConcertIsOver()
        {
            Item item = new Item()
            {
                Name = BackstagePasses,
                SellIn = 0,
                Quality = 7,
            };
            Inventory sut = Inventory.With([item]);

            sut.PassDay();

            item.Quality.Should().Be(MinQuality);
        }

        private static Item Sulfuras()
        {
            return new Item()
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 0,
                Quality = 80,
            };
        }
    }
}