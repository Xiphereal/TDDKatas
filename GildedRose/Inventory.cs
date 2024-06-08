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
                item.UpdateQuality();

                item.ReduceSellInBy1();

                if (item.IsExpired())
                    item.UpdateQualityAfterExpiration();
            }
        }

        private static IEnumerable<ItemWrapper> ExceptSulfuras(
            IEnumerable<ItemWrapper> items)
        {
            return items.Where(x => !x.IsSulfuras());
        }
    }
}