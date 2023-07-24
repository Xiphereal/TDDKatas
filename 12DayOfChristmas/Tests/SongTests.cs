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
        public void Day_1()
        {
            Song.Play(1)
                .Should().ContainEquivalentOf("A partridge in a pear tree");
        }

        [Fact]
        public void Day_2()
        {
            Song.Play(2)
                .Should().EndWithEquivalentOf("Two turtle doves,\r\n"
                    + "And a partridge in a pear tree");
        }
    }
}