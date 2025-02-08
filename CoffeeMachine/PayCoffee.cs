namespace CoffeeMachine;

public class PayCoffee(ServiceCoffee serviceCoffee)
{
    public void Execute(Request request, double payment)
    {
        if (payment > 0)
        {
            serviceCoffee.Execute(request);
        }
    }
}