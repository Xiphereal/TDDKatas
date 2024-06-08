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

        [Fact]
        public void DisplaceTowardsFacingDirection()
        {
            MovesNorth();
            MovesSouth();
            MovesEast();
            MovesWest();
        }

        private static void MovesNorth()
        {
            var sut = new Rover(0, 0, "N");

            sut.Receive("f");

            sut.X.Should().Be(0);
            sut.Y.Should().Be(1);
        }

        private static void MovesSouth()
        {
            var sut = new Rover(0, 0, "S");

            sut.Receive("f");

            sut.X.Should().Be(0);
            sut.Y.Should().Be(-1);
        }

        private static void MovesEast()
        {
            var sut = new Rover(0, 0, "E");

            sut.Receive("f");

            sut.X.Should().Be(1);
            sut.Y.Should().Be(0);
        }

        private static void MovesWest()
        {
            var sut = new Rover(0, 0, "W");

            sut.Receive("f");

            sut.X.Should().Be(-1);
            sut.Y.Should().Be(0);
        }
    }
}
