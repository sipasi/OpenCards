namespace OpenCards.Durak.Collections.DiscardPiles;

public interface IDiscardPile<T> : IReadonlyDiscardPile<T>
{
    void Add(T data);
    void AddRange(IEnumerable<T> datas);

    void Clear();
}