using System;

namespace MarsRoverKata.Tests;

public class Rover
{
    public CardinalPoint Orientation { get; set; }
    public Tuple<int, int> Position;
    private readonly Plateau plateau;

    public Rover(Plateau plateau)
    {
        this.plateau = plateau;
    }

    public void LandAt(int i, int i1)
    {
        Position = new Tuple<int, int>(i, i1);
    }

    public void MoveForward()
    {
        Position = Orientation == CardinalPoint.East
            ? new Tuple<int, int>(Position.Item1 + 1, Position.Item2)
            : new Tuple<int, int>(Position.Item1, Position.Item2 + 1);
    }

    public void RotateRight()
    {
        Orientation = Orientation.RotateRight();
    }

    public void RotateLeft()
    {
        Orientation = Orientation.RotateLeft();
    }
}