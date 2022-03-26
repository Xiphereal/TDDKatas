using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseTests
    {
        [Fact]
        public void Normal_item_Quality_decreases_by_1_when_SellIn_is_not_0()
        {
            Item normalItem = new()
            {
                Quality = 2,
                SellIn = 1
            };
            var sut = new GildedRose();
            sut.Items.Add(normalItem);

            sut.UpdateQuality();

            Assert.Equal(expected: 1, normalItem.Quality);
        }

        [Theory]
        [InlineData("Conjured item name")]
        [InlineData("conjured item name")]
        public void Conjured_item_Quality_decreases_by_2_when_SellIn_is_not_0(string name)
        {
            Item conjuredItem = new()
            {
                Name = name,
                Quality = 2,
                SellIn = 1
            };
            var sut = new GildedRose();
            sut.Items.Add(conjuredItem);

            sut.UpdateQuality();

            Assert.Equal(expected: 0, conjuredItem.Quality);
        }
    }
}