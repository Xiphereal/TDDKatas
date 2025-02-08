using System.Collections;

namespace CoffeeMachine;

public class Catalog(params string[] coffees) : IReadOnlyList<string>
{
    public IEnumerator<string> GetEnumerator()
    {
        return ((IEnumerable<string>)coffees).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => coffees.Length;

    public string this[int index] => coffees[index];
}