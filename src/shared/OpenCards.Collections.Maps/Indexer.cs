using System.Collections;

namespace OpenCards.Collections.Maps;

public class Indexer<TKey, TValue>(Dictionary<TKey, TValue> dictionary) : IIndexer<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>
    where TKey : notnull
{
    private readonly Dictionary<TKey, TValue> dictionary = dictionary;

    public int Count => dictionary.Count;

    public TValue this[TKey index]
    {
        get => dictionary[index];
        set => dictionary[index] = value;
    }

    public Dictionary<TKey, TValue>.Enumerator GetEnumerator() => dictionary.GetEnumerator();

    IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => dictionary.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => dictionary.GetEnumerator();
}