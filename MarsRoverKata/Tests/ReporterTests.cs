using FluentAssertions;
using Xunit;

namespace MarsRoverKata.Tests
{
    public class ReporterTests
    {
        [Fact]
        public void ReportsInitialPosition()
        {
            var plateau = new Plateau();
            var rover = new Rover(plateau);
            rover.LandAt(5, 5);

            rover.Report().Should().Be("5:5:N");
        }
    }
}