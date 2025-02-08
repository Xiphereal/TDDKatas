using FluentAssertions;
using Moq;

namespace CoffeeMachine;

public class Tests
{
    [Test]
    public void NothingIsServedOnEmptyRequest()
    {
        var mockDrinkMaker = new MockDrinkMaker();

        ServiceCoffee.Execute(new Request(), mockDrinkMaker);

        mockDrinkMaker.ServedDrinks.Should().Be(0);
    }

}

public class MockDrinkMaker
{
    public int ServedDrinks { get; set; }
}