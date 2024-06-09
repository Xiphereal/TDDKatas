
namespace GildedRose.Console
{
    public class Inventory(IList<Item> items)
    {
        private const string AgedBrie = "Aged Brie";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const int MaxQuality = 50;

        public static Inventory With(IList<Item> items) => new Inventory(items);

        public void UpdateQuality()
        {
            foreach (Item item in items)
            {
                if (item.Name != AgedBrie && item.Name != BackstagePasses)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != Sulfuras)
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    if (item.Quality < MaxQuality)
                    {
                        item.Quality++;

                        if (item.Name == BackstagePasses)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < MaxQuality)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < MaxQuality)
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (item.Name != Sulfuras)
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != AgedBrie)
                    {
                        if (item.Name != BackstagePasses)
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != Sulfuras)
                                {
                                    item.Quality--;
                                }
                            }
                        }
                        else
                        {
                            item.Quality -= item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < MaxQuality)
                        {
                            item.Quality++;
                        }
                    }
                }
            }
        }
    }
}