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
                UpdateQuality(item);

                item.ReduceSellInBy1();

                if (item.IsExpired())
                    UpdateQualityAgain(item);
            }
        }

        private static void UpdateQualityAgain(Item item)
        {
            if (item.Name != AgedBrie)
            {
                if (item.Name != BackstagePases)
                    item.DecreaseQuality();
                else
                    item.Quality -= item.Quality;
            }
            else
            {
                if (item.Quality < MaxQuality)
                    item.Quality++;
            }
        }

        private static void UpdateQuality(Item item)
        {
            if (IsCommon(item))
                item.DecreaseQuality();
            else
                item.IncreaseQuality();
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