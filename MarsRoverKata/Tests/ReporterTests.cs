﻿using FluentAssertions;
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

        [Fact]
        public void ReportsPositionAfterMoving()
        {
            var plateau = new Plateau();
            var rover = new Rover(plateau);
            rover.LandAt(5, 5);
            rover.MoveForward();

            rover.Report().Should().Be("5:6:N");
        }
        
        [Fact]
        public void ReportObstacle()
        {
            var plateau = new Plateau();
            var rover = new Rover(plateau);
            plateau.Settle( 5, 5);
            plateau.PutObstacle(5, 6);
            
            rover.MoveForward();

            rover.Report().Should().Be("O:5:5:N");
        }
    }
}