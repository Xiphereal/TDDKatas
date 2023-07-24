using FluentAssertions;
using Xunit;

namespace TwelveDayOfChristmas.Tests
{
    public class SongTests
    {
        [Fact]
        public void Starts_with_initial_lines()
        {
            Song.Play().Should().StartWith("On the First day of Christmas,\r\n" +
                "My true love gave to me:");
        }
    }
}