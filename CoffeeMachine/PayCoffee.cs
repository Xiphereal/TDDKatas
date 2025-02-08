namespace CoffeeMachine;

public class PayCoffee(ServiceCoffee serviceCoffee)
{
    public void Execute(Request request, double payment)
    {
        serviceCoffee.Execute(request);
    }
}