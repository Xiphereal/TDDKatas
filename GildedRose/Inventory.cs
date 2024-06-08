namespace GildedRose.Console
{
    public class Inventory
    {
        private const string BackstagePases = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrie = "Aged Brie";
        private const int MaxQuality = 50;

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
                    item.UpdateQualityAfterExpiration();
            }
        }

        private static void UpdateQuality(Item item)
        {
            if (item.IsCommon())
                item.DecreaseQuality();
            else if (item.IsBackstagePasses())
                item.IncreaseQualityForBackstagePasses();
            else if (item.IsAgedBrie())
                item.IncreaseQuality();
        }

        private static IEnumerable<Item> ExceptSulfuras(IList<Item> items)
        {
            return items.Where(x => x.Name != Sulfuras);
        }
    }
}