namespace MarsRoverKata.Tests;

public class MissionControl
{
    readonly Rover doc;

    public MissionControl(Rover doc)
    {
        this.doc = doc;
    }

    public void Order(string input)
    {
        doc.MoveForward();
    }
}