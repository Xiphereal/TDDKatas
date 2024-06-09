
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
            foreach (Item item in ExceptLegendaries(items))
            {
                UpdateQuality(item);

                item.SellIn--;

                if (IsExpired(item))
                {
                    if (item.Name == AgedBrie)
                        IncreaseQuality(item);
                    else
                    {
                        if (item.Name == BackstagePasses)
                            item.Quality -= item.Quality;
                        else
                        {
                            if (item.Quality > MinQuality)
                            {
                                item.Quality--;
                            }
                        }
                    }
                }
            }
        }

        private static void UpdateQuality(Item item)
        {
            if (item.Name != AgedBrie && item.Name != BackstagePasses)
                DecreaseQuality(item);
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
        }

        private static IEnumerable<Item> ExceptLegendaries(IList<Item> items)
        {
            return items.Where(x => x.Name != Sulfuras);
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

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > MinQuality)
                item.Quality--;
        }
    }
}