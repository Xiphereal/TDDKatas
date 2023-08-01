namespace MarsRoverKata.Tests;

public class Rover
{
    public CardinalPoint Orientation { get; set; }
    public (int x, int y) Position => plateau.WhereRoverIs;

    private readonly Plateau plateau;

    public Rover(Plateau plateau)
    {
        this.plateau = plateau;
    }

    public void LandAt(int x, int y)
    {
        plateau.Settle(this, x, y);
    }

    public void MoveForward()
    {
        var delta = Orientation.Direction();

        plateau.Settle(this, Position.x + delta.x, Position.y + delta.y);
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