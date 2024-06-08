using FluentAssertions;
using Xunit;

namespace MarsRoverKata.Tests
{
    public class RoverShould
    {
        [Fact]
        public void StartAtOriginAndFacingWhateverDirectionIsTold()
        {
            var sut = new Rover(0, 0, "N");
            sut.X.Should().Be(0);
            sut.Y.Should().Be(0);
            sut.Direction.Should().Be("N");
        }
    }
}
