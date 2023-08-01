namespace MarsRoverKata.Tests;

public class MissionControl
{
    readonly Rover doc;

    public MissionControl(Rover doc)
    {
        this.doc = doc;
    }

    public void Order(Command input)
    {
        doc.MoveForward();
    }
}