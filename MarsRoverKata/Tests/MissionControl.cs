namespace MarsRoverKata.Tests;

public class MissionControl
{
    private readonly Rover doc;

    public MissionControl(Rover doc)
    {
        this.doc = doc;
    }

    public void Order(string input)
    {
        doc.MoveForward();
    }
}

public readonly struct Command
{
}