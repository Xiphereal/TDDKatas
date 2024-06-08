using FluentAssertions;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseInventoryTests
    {
        // Max quality is 50
        // Min quality is 0
        // Each pass day lowers quality & sell in values
        // aged brie increases quality the older it gets
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


    }
}