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

	internal (int x, int y) PreviewPosition((int x, int y) value)
	{
        var target = (WhereRoverIs.x + value.x, WhereRoverIs.y + value.y);
        if(target.Item1 < 0)
        {
            target = (target.Item1 + 10, target.Item2);
        }

        if(target.Item2 < 0)
        {
            target = (target.Item1, target.Item2 + 10);
        }
		return target;
	}
}