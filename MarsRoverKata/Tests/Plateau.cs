using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata.Tests;

public class Plateau
{
    public readonly int x;
    public readonly int y;
    public (int x, int y) WhereRoverIs { get; set; }
    public IList<(int x, int y)> obstacles;
    public Plateau()
    {
        obstacles = new List<(int x, int y)>();
        x = 10;
        y = 10;
    }

    public void Settle((int x, int y) position)
    {
        Settle(position.x, position.y);
    }
    
    public void Settle( int x, int y)
    {
        if (x > this.x || x < 0)
            throw new ArgumentOutOfRangeException();

        if (y > this.y || y < 0)
            throw new ArgumentOutOfRangeException();

        WhereRoverIs = (x, y);
    }

    public bool Occupied((int x, int y) coords)
    {
        return obstacles.Any(obstacle => obstacle == coords);
    }

    public void PutObstacle(int x, int y)
    {
        obstacles.Add((x, y));
    }

	internal (int x, int y) PositionAt((int, int) value)
	{
		throw new NotImplementedException();
	}
}