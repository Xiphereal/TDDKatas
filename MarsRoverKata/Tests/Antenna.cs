using System;
using System.Diagnostics.CodeAnalysis;

namespace MarsRoverKata.Tests;

public class Antenna
{
	private readonly Rover rover;

	public Antenna([NotNull] Rover rover)
	{
		if (rover is null)
		{
			throw new ArgumentException();
		}

		this.rover = rover;
	}

	public void Receive(Inputs input)
	{
        foreach (var command in input)
        {
            if (command == 'R')
                rover.RotateRight();
            else if (command == 'L')
                rover.RotateLeft();
            else
                rover.MoveForward();
        }
    }
}