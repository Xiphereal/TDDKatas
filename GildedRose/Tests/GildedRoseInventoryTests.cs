using FluentAssertions;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseInventoryTests
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
            GildedRoseInventory sut = CreateInventoryWith(item);

            sut.UpdateQuality();

            item.Quality.Should().Be(0);
        }

        private static GildedRoseInventory CreateInventoryWith(Item item)
        {
            var sut = new GildedRoseInventory();
            sut.Items.Clear();
            sut.Items.Add(item);

            return sut;
        }

        [Theory]
        [InlineData("Aged Brie", 1)]
        [InlineData("Aged Brie", 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1)]
        public void Special_Items_Quality_never_goes_above_50(string itemName, int sellIn)
        {
            Item specialItem = new()
            {
                Name = itemName,
                Quality = 50,
                SellIn = sellIn
            };
            GildedRoseInventory sut = CreateInventoryWith(specialItem);

            sut.UpdateQuality();

            specialItem.Quality.Should().Be(50);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -2)]
        public void Item_SellIn_only_decreases_in_decrements_of_one(int sellIn, int decrementedSellIn)
        {
            Item item = new() { SellIn = sellIn };
            GildedRoseInventory sut = CreateInventoryWith(item);

            sut.UpdateQuality();

            item.SellIn.Should().Be(decrementedSellIn);
        }

        [Fact]
        public void Normal_item_Quality_degrades_by_1_when_sell_date_has_not_passed_yet()
        {
            Item normalItem = new()
            {
                Quality = 2,
                SellIn = 1
            };
            GildedRoseInventory sut = CreateInventoryWith(normalItem);

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
            GildedRoseInventory sut = CreateInventoryWith(normalItem);

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
            GildedRoseInventory sut = CreateInventoryWith(conjuredItem);

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
            GildedRoseInventory sut = CreateInventoryWith(conjuredItem);

            sut.UpdateQuality();

            conjuredItem.Quality.Should().Be(0);
        }

        [Fact]
        public void Aged_Brie_Quality_increases_over_time()
        {
            Item agedBrie = new()
            {
                Name = "Aged Brie",
                Quality = 0,
                SellIn = 1
            };
            GildedRoseInventory sut = CreateInventoryWith(agedBrie);

            sut.UpdateQuality();

            agedBrie.Quality.Should().Be(1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Aged_Brie_Quality_increases_twice_as_fast_when_sell_date_has_passed(int sellIn)
        {
            Item agedBrie = new()
            {
                Name = "Aged Brie",
                Quality = 0,
                SellIn = sellIn
            };
            GildedRoseInventory sut = CreateInventoryWith(agedBrie);

            sut.UpdateQuality();

            agedBrie.Quality.Should().Be(2);
        }

        [Fact]
        public void Sulfuras_Quality_never_degrades_nor_goes_above_80()
        {
            Item sulfuras = CreateSulfuras();
            GildedRoseInventory sut = CreateInventoryWith(sulfuras);

            sut.UpdateQuality();

            sulfuras.Quality.Should().Be(80);
        }

        private static Item CreateSulfuras()
        {
            return new()
            {
                Name = GildedRoseInventory.SulfurasName,
                Quality = 80,
                SellIn = 0
            };
        }

        [Fact]
        public void Sulfuras_SellIn_never_decreases()
        {
            Item sulfuras = CreateSulfuras();
            GildedRoseInventory sut = CreateInventoryWith(sulfuras);

            sut.UpdateQuality();

            sulfuras.SellIn.Should().Be(0);
        }

        [Theory]
        [InlineData(50, 0)]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        [InlineData(50, -1)]
        [InlineData(1, -1)]
        [InlineData(0, -1)]
        public void BackstagePasses_Quality_drops_to_0_after_concert(int quality, int sellIn)
        {
            Item backstagePasses = new()
            {
                Name = GildedRoseInventory.BackstagePassesName,
                Quality = quality,
                SellIn = sellIn
            };
            GildedRoseInventory sut = CreateInventoryWith(backstagePasses);

            sut.UpdateQuality();

            backstagePasses.Quality.Should().Be(0);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(6)]
        public void BackstagePasses_Quality_increases_by_2_each_day_when_there_are_10_days_or_less_until_the_concert(int sellIn)
        {
            Item backstagePasses = new()
            {
                Name = GildedRoseInventory.BackstagePassesName,
                Quality = 1,
                SellIn = sellIn
            };
            GildedRoseInventory sut = CreateInventoryWith(backstagePasses);

            sut.UpdateQuality();

            backstagePasses.Quality.Should().Be(3);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(1)]
        public void BackstagePasses_Quality_increases_by_3_each_day_when_there_are_5_days_or_less_until_the_concert(int sellIn)
        {
            Item backstagePasses = new()
            {
                Name = GildedRoseInventory.BackstagePassesName,
                Quality = 1,
                SellIn = sellIn
            };
            GildedRoseInventory sut = CreateInventoryWith(backstagePasses);

            sut.UpdateQuality();

            backstagePasses.Quality.Should().Be(4);
        }

        [Fact]
        public void BackstagePasses_Quality_increases_only_by_1_each_day_when_there_are_more_than_10_days_until_the_concert()
        {
            Item backstagePasses = new()
            {
                Name = GildedRoseInventory.BackstagePassesName,
                Quality = 1,
                SellIn = 11
            };
            GildedRoseInventory sut = CreateInventoryWith(backstagePasses);

            sut.UpdateQuality();

            backstagePasses.Quality.Should().Be(2);
        }
    }
}