using FluentAssertions;

namespace CoffeeMachine;

public class UnitTests
{
    [Test]
    public void METHOD()
    {
        new Catalog().ASDfasdf().Should().BeEmpty();
    }

    [Test]
    public void CatalogWithCoffe()
    {
        new Catalog("Capuccino").ASDfasdf().Should().BeEquivalentTo(["Capuccino"]);
    }
}