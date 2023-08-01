using System;

namespace MarsRoverKata.Tests;

public class Rover
{
    public CardinalPoint Orientation { get; set; }
    public (int x, int y) Position => plateau.WhereRoverIs;

    private readonly Plateau plateau;

    public Rover(Plateau plateau)
    {
        this.plateau = plateau;
    }

    public void LandAt(int x, int y)
    {
        plateau.Receive(this, x, y);
    }

    public void MoveForward()
    {
        var forward = Orientation == CardinalPoint.East
            ? (Position.Item1 + 1, Position.Item2)
            : (Position.Item1, Position.Item2 + 1);

        plateau.Receive(this, forward.Item1, forward.Item2);
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