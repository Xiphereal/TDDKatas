using FluentAssertions;
using NUnit.Framework.Interfaces;

namespace CoffeeMachine;

public class Tests
{
    [Test]
    public void NothingIsServedOnEmptyRequest()
    {
        var mockDrinkMaker = new MockDrinkMaker();

        new ServiceCoffee(mockDrinkMaker).Execute(new Request());

        mockDrinkMaker.ServedDrinks.Should().Be(0);
    }

    [Test]
    public void ServesDrinkOnValidRequest()
    {
        var mockDrinkMaker = new MockDrinkMaker();

        new ServiceCoffee(mockDrinkMaker).Execute(new Request()
        {
            Coffee = "Capuccino"
        });

        mockDrinkMaker.ServedDrinks.Should().Be(1);
    }
}

public class MockDrinkMaker
{
    public int ServedDrinks { get; set; }
}