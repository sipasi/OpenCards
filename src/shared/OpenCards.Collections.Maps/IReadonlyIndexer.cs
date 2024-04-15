namespace OpenCards.Collections.Maps;

public interface IReadonlyIndexer<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    int Count { get; }

    TValue this[TKey index] { get; }
}