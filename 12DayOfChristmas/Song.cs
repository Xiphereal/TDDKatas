using System.Text;

namespace TwelveDayOfChristmas.Tests
{
    public class Song
    {
        private const int LastDay = 12;

        private static readonly string[] additionalGiftsLines =
        {
            "Twelve drummers drumming",
            "Eleven pipers piping",
            "Ten lords a-leaping",
            "Nine ladies dancing",
            "Eight maids a-milking",
            "Seven swans a-swimming",
            "Six geese a-laying",
            "Five golden rings",
            "Four calling birds",
            "Three French hens",
            "Two turtle doves",
        };

        public static string Play(int day)
        {
            if (day < 1 || day > 12)
                throw new ArgumentOutOfRangeException();

            const string initialLines = "On the First day of Christmas,\r\n" +
                "My true love gave to me:";

            var additionalGifts = new StringBuilder();

            foreach (var line in additionalGiftsLines[Range.StartAt(LastDay - day)])
            {
                additionalGifts.AppendLine($"{line},");
            }

            if (additionalGifts.Any())
            {
                additionalGifts.Append("And ");
            }

            const string lastGift = "a partridge in a pear tree.";

            return initialLines + "\r\n"
                + additionalGifts.ToString()
                + lastGift;
        }
    }
}