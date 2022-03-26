using FluentAssertions;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseTests
    {
        [Theory]
        [InlineData("Normal item", 1)]
        [InlineData("Normal item", 0)]
        [InlineData("Normal item", -1)]
        [InlineData("Conjured item", 1)]
        [InlineData("Conjured item", 0)]
        [InlineData("Conjured item", -1)]
        public void Item_Quality_is_never_negative(string itemName, int sellIn)
        {
            Item item = new()
            {
                Name = itemName,
                Quality = 0,
                SellIn = sellIn
            };
            var sut = new GildedRose();
            sut.Items.Add(item);

            sut.UpdateQuality();

            item.Quality.Should().Be(0);
        }

        [Fact]
        public void Normal_item_Quality_degrades_by_1_when_sell_date_has_not_passed_yet()
        {
            Item normalItem = new()
            {
                Quality = 2,
                SellIn = 1
            };
            var sut = new GildedRose();
            sut.Items.Add(normalItem);

            sut.UpdateQuality();

            normalItem.Quality.Should().Be(1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Normal_item_Quality_degrades_twice_as_fast_when_sell_date_has_passed(int passedSellIn)
        {
            Item normalItem = new()
            {
                Quality = 2,
                SellIn = passedSellIn
            };
            var sut = new GildedRose();
            sut.Items.Add(normalItem);

            sut.UpdateQuality();

            normalItem.Quality.Should().Be(0);
        }

        [Theory]
        [InlineData("Conjured item name")]
        [InlineData("conjured item name")]
        public void Conjured_item_Quality_degrades_by_2_when_sell_date_has_not_passed_yet(string name)
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

            conjuredItem.Quality.Should().Be(0);
        }

        [Theory]
        [InlineData("Conjured item name", 0)]
        [InlineData("conjured item name", -1)]
        public void Conjured_item_Quality_degrades_by_2_when_sell_date_has_passed(
            string name,
            int passedSellIn)
        {
            Item conjuredItem = new()
            {
                Name = name,
                Quality = 4,
                SellIn = passedSellIn
            };
            var sut = new GildedRose();
            sut.Items.Add(conjuredItem);

            sut.UpdateQuality();

            conjuredItem.Quality.Should().Be(0);
        }
    }
}