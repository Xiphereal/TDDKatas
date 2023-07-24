using FluentAssertions;
using Xunit;

namespace TwelveDayOfChristmas.Tests
{
    public class SongTests
    {
        [Fact]
        public void Starts_with_initial_lines()
        {
            Song.Play(1)
                .Should().StartWith("On the First day of Christmas,\r\n"
                    + "My true love gave to me:");
        }

        [Fact]
        public void First_day()
        {
            Song.Play(1)
                .Should().ContainEquivalentOf("A partridge in a pear tree.");
        }

        [Fact]
        public void And_conjunction_is_added_when_more_than_one_gift()
        {
            Song.Play(2)
                .Should().Contain("And");
        }

        [Fact]
        public void All_days()
        {
            Song.Play(12)
                .Should().EndWithEquivalentOf(
                    "Twelve drummers drumming,\r\n" +
                    "Eleven pipers piping,\r\n" +
                    "Ten lords a-leaping,\r\n" +
                    "Nine ladies dancing,\r\n" +
                    "Eight maids a-milking,\r\n" +
                    "Seven swans a-swimming,\r\n" +
                    "Six geese a-laying,\r\n" +
                    "Five golden rings,\r\n" +
                    "Four calling birds,\r\n" +
                    "Three French hens,\r\n" +
                    "Two turtle doves,\r\n" +
                    "And a partridge in a pear tree.");
        }
    }
}