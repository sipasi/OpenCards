namespace OpenCards.Collections.Maps;

public interface IIndexer<TKey, TValue> : IReadonlyIndexer<TKey, TValue>
{
    new TValue this[TKey index] { get; set; }
}