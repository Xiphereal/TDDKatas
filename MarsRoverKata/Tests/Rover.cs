using System;
using System.Diagnostics.CodeAnalysis;

namespace MarsRoverKata.Tests;

public class Rover
{
	public CardinalPoint Orientation { get; set; }
	public (int x, int y) Position => plateau.WhereRoverIs;

	private readonly Plateau plateau;

	public Rover([NotNull] Plateau plateau)
	{
		if (plateau is null)
			throw new ArgumentException();

		this.plateau = plateau;
	}

	public void LandAt(int x, int y)
	{
		plateau.Settle( x, y);
	}

	public void MoveForward()
	{
		var delta = Orientation.Direction();

        if(!plateau.Occupied((Position.x + delta.x, Position.y + delta.y)))
        {
            plateau.Settle( Position.x + delta.x, Position.y + delta.y);
        }
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