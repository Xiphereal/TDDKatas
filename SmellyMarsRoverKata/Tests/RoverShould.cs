using FluentAssertions;
using Xunit;

namespace MarsRoverKata.Tests
{
    public class RoverShould
    {
        private const char N = 'N';
        private const char E = 'E';
        private const char S = 'S';
        private const char W = 'W';

        [Fact]
        public void StartAtOriginAndFacingWhateverDirectionIsTold()
        {
            var sut = new Rover(0, 0, N);
            sut.X.Should().Be(0);
            sut.Y.Should().Be(0);
            sut.Direction.Should().Be(N);
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
            var sut = new Rover(0, 0, N);

            sut.Receive("f");

            sut.X.Should().Be(0);
            sut.Y.Should().Be(1);
        }

        private static void MovesSouth()
        {
            var sut = new Rover(0, 0, S);

            sut.Receive("f");

            sut.X.Should().Be(0);
            sut.Y.Should().Be(-1);
        }

        private static void MovesEast()
        {
            var sut = new Rover(0, 0, E);

            sut.Receive("f");

            sut.X.Should().Be(1);
            sut.Y.Should().Be(0);
        }

        private static void MovesWest()
        {
            var sut = new Rover(0, 0, W);

            sut.Receive("f");

            sut.X.Should().Be(-1);
            sut.Y.Should().Be(0);
        }

        [Fact]
        public void ChangeDirectionByRotating()
        {
            var sut = new Rover(0, 0, N);

            sut.Receive("r");
            sut.Direction.Should().Be(E);

            sut.Receive("l");
            sut.Direction.Should().Be(N);
        }


        [Fact]
        public void AcceptASequenceOfCommands()
        {
            var sut = new Rover(0, 0, N);

            sut.Receive("rfr");

            sut.X.Should().Be(1);
            sut.Y.Should().Be(0);
            sut.Direction.Should().Be(S);
        }
    }
}
