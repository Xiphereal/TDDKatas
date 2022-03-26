namespace GildedRose.Console
{
    internal class Program
    {
        private static IList<Item> Items;

        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            GildedRose gildedRose = new();

            Items = gildedRose.items;

            gildedRose.UpdateQuality();

            System.Console.ReadKey();
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}