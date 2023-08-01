using System;

namespace MarsRoverKata.Tests;

public static class SteeringWheel
{
    public static CardinalPoint RotateRight(this CardinalPoint origin)
    {
        return origin switch
        {
            CardinalPoint.North => CardinalPoint.East,
            CardinalPoint.East => CardinalPoint.South,
            CardinalPoint.South => CardinalPoint.West,
            CardinalPoint.West => CardinalPoint.North,
            _ => throw new ArgumentOutOfRangeException(nameof(origin), origin, null)
        };
    }

    public static CardinalPoint RotateLeft(this CardinalPoint origin)
    {
        return origin switch
        {
            CardinalPoint.North => CardinalPoint.West,
            CardinalPoint.West => CardinalPoint.South,
            CardinalPoint.South => CardinalPoint.East,
            CardinalPoint.East => CardinalPoint.North,
            _ => throw new ArgumentOutOfRangeException(nameof(origin), origin, null)
        };
    }

    public static (int x, int y) Direction(this CardinalPoint orientation)
    {
        return orientation switch
        {
            CardinalPoint.North => (0, 1),
            CardinalPoint.East => (1, 0),
            CardinalPoint.South => (0, -1),
            CardinalPoint.West => (-1, 0),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}