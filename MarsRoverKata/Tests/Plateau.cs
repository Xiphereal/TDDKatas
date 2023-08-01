namespace MarsRoverKata.Tests;

public class Plateau
{
    public readonly int x;
    public readonly int y;
    private int roverX;
    private int roverY;

    public Plateau()
    {
        x = 10;
        y = 10;
    }

    public void Receive(Rover rover, int x, int y)
    {
        roverX = x;
        roverY = y;
    }
}