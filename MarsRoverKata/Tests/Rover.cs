using System;
using System.Diagnostics.CodeAnalysis;

namespace MarsRoverKata.Tests;

public class Rover
{
    public CardinalPoint Orientation { get; set; }
    public (int x, int y) Position => plateau.WhereRoverIs;

    private readonly Plateau plateau;
    public bool Stuck { get; private set; }

    public Rover([NotNull] Plateau plateau)
    {
        if (plateau is null)
            throw new ArgumentException();

        this.plateau = plateau;
    }

    public void LandAt(int x, int y)
    {
        plateau.Settle(x, y);
    }

    public bool MoveForward()
    {
        Stuck = false;

        var delta = Orientation.Direction();
        var targetPosition = plateau.PreviewPosition(delta);

        Stuck = plateau.Occupied(targetPosition);

		if (!Stuck)
        {
            plateau.Settle(targetPosition);
        }

        return !Stuck;
    }

    public void RotateRight()
    {
        Orientation = Orientation.RotateRight();
    }

    public void RotateLeft()
    {
        Orientation = Orientation.RotateLeft();
    }

    public string Report()
    {
        var result = Position.x + ":" + Position.y + ":" + Orientation.ToString()[0];
        if (Stuck)
        {
            result = "O:" + result;
        }

        return result;
    }
}