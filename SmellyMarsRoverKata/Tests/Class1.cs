using FluentAssertions;
using Xunit;

namespace MarsRoverKata.Tests
{
    public class Class1
    {
        [Fact]
        public void TestName()
        {
            var sut = new Rover(0, 0, "N");
            sut.X.Should().Be(0);
            sut.Y.Should().Be(0);
        }
    }
}
