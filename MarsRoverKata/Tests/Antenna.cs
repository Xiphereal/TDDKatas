﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace MarsRoverKata.Tests;

public class Antenna
{
	readonly Rover rover;

    public string LastReport => rover.Report();
    
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
			{
                var hasMoved = rover.MoveForward();

                if (!hasMoved)
                {
					break;
                }
			}
        }
    }
}