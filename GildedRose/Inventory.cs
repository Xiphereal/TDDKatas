
namespace GildedRose.Console
{
    public class Inventory
    {
        private const string BackstagePases = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrie = "Aged Brie";
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        private IList<Item> Items = [];

        public static Inventory Empty => new();

        public Inventory With(params Item[] items)
        {
            Items = items.ToList();

            return this;
        }

        public void PassDay()
        {
            foreach (Item item in ExceptSulfuras(Items))
            {
                if (IsCommon(item))
                {
                    if (item.Quality > MinQuality)
                    {
                        item.Quality--;
                    }
                }
                else
                {
                    if (item.Quality < MaxQuality)
                    {
                        item.Quality++;

                        if (item.Name == BackstagePases)
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

                item.SellIn--;

                if (item.SellIn < MinQuality)
                {
                    if (item.Name != AgedBrie)
                    {
                        if (item.Name != BackstagePases)
                        {
                            if (item.Quality > MinQuality)
                            {
                                item.Quality--;
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

        private static IEnumerable<Item> ExceptSulfuras(IList<Item> items)
        {
            return items.Where(x => x.Name != Sulfuras);
        }

        private static bool IsCommon(Item item)
        {
            return item.Name != AgedBrie && item.Name != BackstagePases;
        }
    }
}