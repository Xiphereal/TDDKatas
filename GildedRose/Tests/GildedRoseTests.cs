using FluentAssertions;
using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseInventoryTests
    {
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

        [Fact]
        public void TestName()
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
    }
}