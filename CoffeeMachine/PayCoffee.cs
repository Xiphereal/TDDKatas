namespace CoffeeMachine;

public class PayCoffee
{
    private readonly ServiceCoffee serviceCoffee;
    private readonly Catalog catalog;

    public PayCoffee(ServiceCoffee serviceCoffee)
    {
        this.serviceCoffee = serviceCoffee;
        this.catalog = new Catalog("Cappuccino");
    }

    public void Execute(Request request, double payment)
    {
        if (payment > 0 && catalog.ASDfasdf().Contains(request.Coffee))
        {
            serviceCoffee.Execute(request);
        }
    }
}