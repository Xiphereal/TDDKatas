using System.Collections;

namespace CoffeeMachine;

public class Catalog(params string[] coffes) : IReadOnlyList<string>
{
    public IReadOnlyList<string> ASDfasdf()
    {
        return coffes;
    }

    public IEnumerator<string> GetEnumerator()
    {
        return ((IEnumerable<string>)coffes).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => coffes.Length;

    public string this[int index] => coffes[index];
}