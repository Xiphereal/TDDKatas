using System.Text;

namespace TwelveDayOfChristmas.Tests
{
    public class Song
    {
        public static string Play(int day)
        {
            const string initialLines = "On the First day of Christmas,\r\n" +
                "My true love gave to me:";

            var gifts = new StringBuilder();

            if (day == 2)
            {
                gifts.AppendLine("Two turtle doves,");
            }

            if (gifts.Any())
            {
                gifts.Append("And ");
            }

            const string lastGift = "a partridge in a pear tree";

            return initialLines + "\r\n"
                + gifts.ToString()
                + lastGift;
        }
    }
}