namespace CoffeeMachine;

public class ServiceCoffee
{
    private MockDrinkMaker mockDrinkMaker;

    public ServiceCoffee(MockDrinkMaker mockDrinkMaker)
    {
        this.mockDrinkMaker = mockDrinkMaker;
    }

    public void Execute(Request request)
    {
        if (request.Coffee is not null)
        {
            mockDrinkMaker.ServedDrinks = 1;
        }
    }
}