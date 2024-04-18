using System.Collections;
 
namespace OpenCards.Collections.Hands;

public class Hand<T> : IHand<T>
{
    private readonly List<T> items = new(capacity: 6);

    public int Count => items.Count;

    public T this[int index] => items[index];

    public void Add(T card)
    {
        items.Add(card);
    }
    public void Add(IEnumerable<T> cards)
    {
        items.AddRange(cards);
    }
    public void Remove(T card)
    {
        items.Remove(card);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
}
