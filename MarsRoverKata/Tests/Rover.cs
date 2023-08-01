using System;

namespace MarsRoverKata.Tests;

public class Rover
{
    public CardinalPoint Orientation { get; set; }
    public Tuple<int, int> Position { get => position; set => position = value; }

    private Tuple<int, int> position;
    private readonly Plateau plateau;

    public Rover(Plateau plateau)
    {
        this.plateau = plateau;
    }

    public void LandAt(int x, int y)
    {
        Position = new Tuple<int, int>(x, y);
        plateau.Receive(this, x, y);
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