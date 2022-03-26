using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseTests
    {
        [Fact]
        public void Normal_item_Quality_decreases_by_1()
        {
            Item normalItem = new()
            {
                Quality = 1,
                SellIn = 0
            };
            var sut = new GildedRose();
            sut.items.Add(normalItem);

            sut.UpdateQuality();

            Assert.Equal(expected: 0, normalItem.Quality);
        }
    }
}