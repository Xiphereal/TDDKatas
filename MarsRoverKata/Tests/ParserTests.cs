using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace MarsRoverKata.Tests;

public class ParserTests
{
    [Fact]
    public void Receive_MoveForwardCommand()
    {
        var otroDocmás = new Plateau();
        var doc = new Rover(otroDocmás);

        var sut = new Antenna(doc);
        sut.Receive("M");

        doc.Position.Should().Be((0, 1));
    }

    [Fact]
    public void Receive_RotateRightAndMoveCommands()
    {
        var plateau = new Plateau();
        var rover = new Rover(plateau);

        var sut = new Antenna(rover);
        sut.Receive("RM");

        rover.Position.Should().Be((1, 0));
    }

    [Fact]
    public void Receive_RotateLeftAndMoveCommands()
    {
        var plateau = new Plateau();
        var rover = new Rover(plateau);
        plateau.Settle( 5, 5);

        var sut = new Antenna(rover);
        sut.Receive("LM");

        rover.Position.Should().Be((4, 5));
    }

    [Fact]
    public void Receive_RotateLeftAndMoveCommands_WithObstacle_ThenNoMovement()
    {
        var plateau = new Plateau();
        var rover = new Rover(plateau);
        plateau.Settle( 5, 5);
        plateau.PutObstacle(4, 5);

        var sut = new Antenna(rover);
        sut.Receive("LM");

        rover.Position.Should().Be((5, 5));
    }

    [Fact]
    public void IgnoreCommandWhenDetectsAnObstacle()
    {
        var plateau = new Plateau();
        var rover = new Rover(plateau);
        plateau.Settle( 5, 5);
        plateau.PutObstacle(4, 5);

        var sut = new Antenna(rover);
        sut.Receive("LMRM");

        rover.Position.Should().Be((5, 5));
        rover.Orientation.Should().Be(CardinalPoint.West);
    }


}