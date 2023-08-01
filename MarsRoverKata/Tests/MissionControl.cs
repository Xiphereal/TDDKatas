using System;
using System.Diagnostics.CodeAnalysis;

namespace MarsRoverKata.Tests;

public class MissionControl
{
	private readonly Rover doc;

	public MissionControl([NotNull] Rover rover)
	{
		if (rover is null)
		{
			throw new ArgumentException();
		}

		doc = rover;
	}

	public void Order(Command input)
	{
		doc.MoveForward();
	}
}