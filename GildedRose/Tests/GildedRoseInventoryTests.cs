using FluentAssertions;
using GildedRose.Console;
using System;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseInventoryTests
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePases = "Backstage passes to a TAFKAL80ETC concert";

        // When SellIn date has passed, quality degrades twice as fast

        // feat: conjured items degrade quality twice as fast as normal ones

        [Fact]
        public void BothQualityAndSellIn_ReducesBy1_AfterEachDayPasses()
        {
            Item item = new Item()
            {
                Quality = 2,
                SellIn = 1,
            };
            var sut = Inventory.Empty.With(item);

            sut.PassDay();

            item.Quality.Should().Be(1);
            item.SellIn.Should().Be(0);
        }

        [Fact]
        public void QualityDegradesTwiceAsFast_WhenSellInHasPassed()
        {
            Item item = new Item()
            {
                Quality = 2,
                SellIn = 0,
            };
            var sut = Inventory.Empty.With(item);

            sut.PassDay();

            item.Quality.Should().Be(0);
        }

        [Fact]
        public void QualityCanNotDropBelow0()
        {
            Item item = new Item()
            {
                Quality = 1,
            };
            var sut = Inventory.Empty.With(item);

            sut.PassDay();
            item.Quality.Should().Be(0);

            sut.PassDay();
            item.Quality.Should().Be(0);
        }

        [Fact]
        public void AgedBrie_IncreasesQualityOverTime()
        {
            Item item = new Item()
            {
                Name = AgedBrie,
                Quality = 1,
            };
            var sut = Inventory.Empty.With(item);

            sut.PassDay();

            item.Quality.Should().BeGreaterThan(1);
        }

        [Fact]
        public void QualityCanNotGoAbove50()
        {
            Item item = new Item()
            {
                Name = AgedBrie,
                Quality = 49,
            };
            var sut = Inventory.Empty.With(item);

            sut.PassDay();
            item.Quality.Should().Be(50);

            sut.PassDay();
            item.Quality.Should().Be(50);
        }

        [Fact]
        public void BackstagePasses_IncreaseQualityBy2_WhenThereAre10daysOrLess()
        {
            Item item = new Item()
            {
                Name = BackstagePases,
                SellIn = 10,
                Quality = 0,
            };
            var sut = Inventory.Empty.With(item);

            sut.PassDay();

            item.Quality.Should().Be(2);
        }

        [Fact]
        public void BackstagePasses_IncreaseQualityBy3_WhenThereAre5daysOrLess()
        {
            Item item = new Item()
            {
                Name = BackstagePases,
                SellIn = 5,
                Quality = 0,
            };
            var sut = Inventory.Empty.With(item);

            sut.PassDay();

            item.Quality.Should().Be(3);
        }

        [Fact]
        public void BackstagePasses_AreUseless_WhenConcertIsOver()
        {
            Item item = new Item()
            {
                Name = BackstagePases,
                SellIn = 0,
                Quality = 50,
            };
            var sut = Inventory.Empty.With(item);

            sut.PassDay();

            item.Quality.Should().Be(0);
        }

        [Fact]
        public void SulfurasHasNotSellIn_NorQualityDecrement()
        {
            Item item = Sulfuras();
            var sut = Inventory.Empty.With(item);

            Execute(sut.PassDay, times: 100);

            item.Quality.Should().Be(Sulfuras().Quality);
            item.SellIn.Should().Be(Sulfuras().SellIn);
        }

        private void Execute(Action what, int times)
        {
            for (int i = 0; i < times; i++)
                what();
        }

        private static Item Sulfuras()
        {
            return new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 0,
                Quality = 80
            };
        }
    }
}