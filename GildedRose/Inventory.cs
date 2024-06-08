
namespace GildedRose.Console
{
    public class Inventory
    {
        private const string BackstagePases = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrie = "Aged Brie";

        private IList<Item> Items = [];

        public static Inventory Empty => new();

        public Inventory With(params Item[] items)
        {
            Items = items.ToList();

            return this;
        }

        public void PassDay()
        {
            foreach (Item item in Items)
            {
                if (item.Name != AgedBrie && item.Name != BackstagePases)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != Sulfuras)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == BackstagePases)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (item.Name != Sulfuras)
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != AgedBrie)
                    {
                        if (item.Name != BackstagePases)
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != Sulfuras)
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }


    }
}