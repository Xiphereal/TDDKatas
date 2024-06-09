
namespace GildedRose.Console
{
    public class Inventory(IList<Item> items)
    {
        private const string AgedBrie = "Aged Brie";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        public static Inventory With(IList<Item> items) => new Inventory(items);

        public void UpdateQuality()
        {
            foreach (Item item in items)
            {
                if (item.Name != AgedBrie && item.Name != BackstagePasses)
                {
                    if (item.Quality > MinQuality)
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
                            if (item.SellIn <= 10)
                                IncreaseQuality(item);

                            if (item.SellIn <= 5)
                                IncreaseQuality(item);
                        }
                    }
                }

                if (item.Name != Sulfuras)
                {
                    item.SellIn--;
                }

                if (IsExpired(item))
                {
                    if (item.Name == AgedBrie)
                    {
                        IncreaseQuality(item);
                    }
                    else
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
                }
            }
        }

        private static bool IsExpired(Item item)
        {
            return item.SellIn < 0;
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < MaxQuality)
                item.Quality++;
        }
    }
}