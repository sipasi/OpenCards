using System.Collections;

using OpenCards.Collections.Indexes;

namespace OpenCards.Collections.Decks;

public class Deck<T>(IReadOnlyList<T> datas, IIndexCollection indexes) : IDeck<T>
{
    private readonly IReadOnlyList<T> datas = datas;
    private readonly IIndexCollection indexes = indexes;

    public int Capacity => datas.Count;
    public int Count => indexes.Count;

    public bool IsEmpty => indexes.IsEmpty;

    public void Shuffle()
    {
        Reset();

        indexes.Randomize(times: 12);

        OnShuffled(datas, indexes);
    }

    public T? Draw()
    {
        if (IsEmpty)
            return default;

        int last = indexes.Next();

        T item = datas[last];

        return item;
    }

    public void Reset() => indexes.ResetIndex();

    protected virtual void OnShuffled(IReadOnlyList<T> datas, IReadonlyIndexCollection indexes) { }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (int index in indexes)
        {
            yield return datas[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}