using System.Collections;

namespace OpenCards.Durak.Collections.DiscardPiles;

public class DiscardPile<T> : IDiscardPile<T>
{
    private readonly List<T> collection = [];

    public int Count => collection.Count;

    public T this[int index] => collection[index];

    public void Add(T data)
    {
        collection.Add(data);
    }
    public void AddRange(IEnumerable<T> datas)
    {
        collection.AddRange(datas);
    }

    public void Clear() => collection.Clear();

    public IEnumerator<T> GetEnumerator() => collection.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => collection.GetEnumerator();
}