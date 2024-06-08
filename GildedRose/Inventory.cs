namespace GildedRose.Console
{
    public class Inventory
    {
        private IEnumerable<ItemWrapper> Items = [];

        public static Inventory Empty => new();

        public Inventory With(params Item[] items)
        {
            Items = items.Wrap();

            return this;
        }

        public void PassDay()
        {
            foreach (ItemWrapper item in ExceptSulfuras(Items))
            {
                UpdateQuality(item);

                item.ReduceSellInBy1();

                if (item.IsExpired())
                    item.UpdateQualityAfterExpiration();
            }
        }

        private static void UpdateQuality(ItemWrapper item)
        {
            if (item.IsCommon() || item.IsAgedBrie())
                item.UpdateQuality();
            else if (item.IsBackstagePasses())
                item.IncreaseQualityForBackstagePasses();
        }

        private static IEnumerable<ItemWrapper> ExceptSulfuras(
            IEnumerable<ItemWrapper> items)
        {
            return items.Where(x => !x.IsSulfuras());
        }
    }
}