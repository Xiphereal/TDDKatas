using FluentAssertions;

namespace CoffeeMachine;

public class IntegrationTests
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

        new ServiceCoffee(mockDrinkMaker).Execute(RequestCappuccino());

        mockDrinkMaker.ServedDrinks.Should().Be(1);
    }

    private static Request RequestCappuccino()
    {
        return new Request()
        {
            Coffee = "Cappuccino"
        };
    }

    private static Request RequestOutOfCatalogCoffee()
    {
        return new Request()
        {
            Coffee = "Out of catalog"
        };
    }

    [Test]
    public void CoffeeIsPaid_SoItIsServed()
    {
        var mockDrinkMaker = new MockDrinkMaker();

        new PayCoffee(new ServiceCoffee(mockDrinkMaker))
            .Execute(RequestCappuccino(), payment: 1.0);

        mockDrinkMaker.ServedDrinks.Should().Be(1);
    }

    [Test]
    public void CoffeeIsNotPaid_ItIsNotServed()
    {
        var mockDrinkMaker = new MockDrinkMaker();

        new PayCoffee(new ServiceCoffee(mockDrinkMaker))
            .Execute(RequestCappuccino(), payment: 0);

        mockDrinkMaker.ServedDrinks.Should().Be(0);
    }

    [Test]
    public void CoffeeIsNotInCatalog_ItIsNotServed()
    {
        var mockDrinkMaker = new MockDrinkMaker();

        new PayCoffee(new ServiceCoffee(mockDrinkMaker))
            .Execute(RequestOutOfCatalogCoffee(), payment: 1);

        mockDrinkMaker.ServedDrinks.Should().Be(0);
    }
}

public class MockDrinkMaker
{
    public int ServedDrinks { get; set; }


    public void Serve()
    {
        ServedDrinks = 1;
    }
}