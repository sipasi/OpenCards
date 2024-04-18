namespace OpenCards.Collections.Hands;

public interface IHand<T> : IReadOnlyHand<T>
{
    void Add(T item);
    void Add(IEnumerable<T> items);

    void Remove(T item);
}
