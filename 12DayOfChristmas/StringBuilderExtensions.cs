using System.Text;

namespace TwelveDayOfChristmas
{
    internal static class StringBuilderExtensions
    {
        public static bool Any(this StringBuilder sb)
        {
            return sb.Length > 1;
        }
    }
}