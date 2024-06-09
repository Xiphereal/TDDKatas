namespace GildedRose.Console
{
    public class Program
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        private IList<Item> Items;

        public static Program Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = MinQuality},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 15,
                            Quality = 20
                        },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }
            };

            app.PassDay();

            ////System.Console.ReadKey();

            return app;
        }

        public IEnumerable<Item> PassDay()
        {
            foreach (Item item in ExceptSulfuras(Items))
            {
                DecreaseSellIn(item);

                UpdateQuality(item);

                if (IsExpired(item))
                    UpdateQualityAgain(item);
            }

            return Items;
        }

        private static void UpdateQualityAgain(Item item)
        {
            if (item.Name != "Aged Brie")
            {
                if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    DecreaseQuality(item);
                }
                else
                {
                    item.Quality -= item.Quality;
                }
            }
            else
            {
                IncreaseQuality(item);
            }
        }

        private static bool IsExpired(Item item)
        {
            return item.SellIn < 0;
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }

        private static void UpdateQuality(Item item)
        {
            if (DegradesOverTime(item))
                DecreaseQuality(item);
            else
            {
                IncreaseQuality(item);

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn <= 10)
                    {
                        IncreaseQuality(item);
                    }

                    if (item.SellIn <= 5)
                    {
                        IncreaseQuality(item);
                    }
                }
            }
        }

        private static bool DegradesOverTime(Item item)
        {
            return item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert";
        }

        private static IEnumerable<Item> ExceptSulfuras(IEnumerable<Item> items)
        {
            return items.Where(x => x.Name != "Sulfuras, Hand of Ragnaros");
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < MaxQuality)
                item.Quality++;
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > MinQuality)
                item.Quality--;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}