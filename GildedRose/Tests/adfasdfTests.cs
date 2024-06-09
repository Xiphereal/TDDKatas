using FluentAssertions;
using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRose.Tests
{
    public class adfasdfTests
    {
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";

        // test: ver si hay una forma más semántica de hacer el AllSatisfy
        // reordenar tests para que sigan criterio más importante y sencillo.

        [Fact]
        public void IsRefactorOver()
        {
            // And we should readd the System.Console.ReadKey();
            Console.Program.Main([]).Should().BeNull();
        }

        [Fact]
        public void Characterization_After2Days()
        {
            IEnumerable<Item> items = PassDays(2);

            items.Should().BeEquivalentTo(
            [
                new Item {Name = "+5 Dexterity Vest", SellIn = 8, Quality = 18},
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 2},
                new Item {Name = "Elixir of the Mongoose", SellIn = 3, Quality = 5},
                new Item {Name = Sulfuras, SellIn = 0, Quality = 80},
                new Item
                    {
                        Name = BackstagePasses,
                        SellIn = 13,
                        Quality = 22
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 1, Quality = 4}
            ]);
        }

        [Fact]
        public void Characterization_After3Days()
        {
            IEnumerable<Item> items = PassDays(3);

            items.Should().BeEquivalentTo(
            [
                new Item {Name = "+5 Dexterity Vest", SellIn = 7, Quality = 17},
                new Item {Name = "Aged Brie", SellIn = -1, Quality = 4},
                new Item {Name = "Elixir of the Mongoose", SellIn = 2, Quality = 4},
                new Item {Name = Sulfuras, SellIn = 0, Quality = 80},
                new Item
                    {
                        Name = BackstagePasses,
                        SellIn = 12,
                        Quality = 23
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 3}
            ]);
        }

        [Fact]
        public void Characterization_SulfurasNeverExpires_AndQualityDoesNotChange()
        {
            IEnumerable<Item> items = PassDays(100);

            Item sulfuras = GetItemBy(name: Sulfuras, items);
            sulfuras.SellIn.Should().Be(0);
            sulfuras.Quality.Should().Be(80);
        }

        [Fact]
        public void QualityNeverDegradesBelow0()
        {
            IEnumerable<Item> items = PassDays(20);

            items.All(x => x.Quality >= 0).Should().BeTrue();
        }

        [Fact]
        public void QualityNeverGoesAbove50_ExceptForSulfuras()
        {
            IEnumerable<Item> items = PassDays(100);

            items.Where(x => x.Name != Sulfuras).All(x => x.Quality <= 50)
                .Should().BeTrue();
        }

        [Fact]
        public void BackstagePasses_QualityIncreaseOverTime()
        {
            int qualityBefore = GetItemBy(BackstagePasses, PassDays(2)).Quality;

            GetItemBy(BackstagePasses, PassDays(3)).Quality
                .Should().BeGreaterThan(qualityBefore);
        }

        private IEnumerable<Item> PassDays(int times)
        {
            Console.Program gildedRose = Console.Program.Main([]);

            // The 2 is because Main already pass a day, as well as UpdateQuality.
            Repeat(() => gildedRose.UpdateQuality(), times - 2);

            IEnumerable<Item> items = gildedRose.UpdateQuality();

            return items;
        }

        private static Item GetItemBy(string name, IEnumerable<Item> items)
        {
            return items.Single(x => x.Name == name);
        }

        private void Repeat(Action action, int times)
        {
            for (int i = 0; i < times; i++)
            {
                action();
            }
        }
    }
}