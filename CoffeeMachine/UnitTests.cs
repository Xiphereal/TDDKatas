using FluentAssertions;

namespace CoffeeMachine;

public class UnitTests
{
    [Test]
    public void METHOD()
    {
        new Catalog().Should().BeEmpty();
    }

    [Test]
    public void CatalogWithCoffe()
    {
        new Catalog("Capuccino").Should().BeEquivalentTo(["Capuccino"]);
    }
}