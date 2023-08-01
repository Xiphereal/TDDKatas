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
		plateau.Receive(this, x, y);
	}

	public void MoveForward()
	{
		var forward = Direction();

		plateau.Receive(this, forward.Item1, forward.Item2);
	}

	private (int, int) Direction()
	{
		switch (Orientation)
		{
			case CardinalPoint.North:
				return (0, 1);
			case CardinalPoint.East:

				break;
			case CardinalPoint.South:
				break;
			case CardinalPoint.West:
				break;
			default:
				break;
		}

		return Orientation == CardinalPoint.East
			? (Position.x + 1, Position.y)
			: (Position.x, Position.y + 1);
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