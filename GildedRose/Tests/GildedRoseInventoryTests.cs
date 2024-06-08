using FluentAssertions;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseInventoryTests
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePases = "Backstage passes to a TAFKAL80ETC concert";

        // backstage passes increase quality by 2 when there are 10 days or less
        // backstage passes increase quality by 3 when there are 5 days or less
        // backstage passes has quality 0 after the SellIn expires
        // Sulfuras has no SellIn nor quality decrement
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

            sut.Degrade();

            item.Quality.Should().Be(1);
            item.SellIn.Should().Be(0);
        }

        [Fact]
        public void QualityCanNotDropBelow0()
        {
            Item item = new Item()
            {
                Quality = 1,
            };
            var sut = Inventory.Empty.With(item);

            sut.Degrade();
            item.Quality.Should().Be(0);

            sut.Degrade();
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

            sut.Degrade();

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

            sut.Degrade();
            item.Quality.Should().Be(50);

            sut.Degrade();
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

            sut.Degrade();

            item.Quality.Should().Be(2);
        }
    }
}