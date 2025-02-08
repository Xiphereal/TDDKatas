using FluentAssertions;

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
}

public class MockDrinkMaker
{
    public int ServedDrinks { get; set; }
}