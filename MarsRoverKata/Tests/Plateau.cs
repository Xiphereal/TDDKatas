using System;

namespace MarsRoverKata.Tests;

public class Plateau
{
    public readonly int x;
    public readonly int y;
    public (int x, int y) WhereRoverIs { get; set; }

    public Plateau()
    {
        x = 10;
        y = 10;
    }

    public void Receive(Rover rover, int x, int y)
    {
        if(x > this.x || x < 0)
            throw new ArgumentOutOfRangeException();
        
        if(y > this.y || y < 0)
            throw new ArgumentOutOfRangeException();
        
        WhereRoverIs = (x, y);
    }
}