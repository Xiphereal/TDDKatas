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
		rover.MoveForward();
    }
}