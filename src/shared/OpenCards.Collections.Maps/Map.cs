namespace OpenCards.Collections.Maps;

public sealed class Map<T1, T2> : IMap<T1, T2>
    where T1 : notnull
    where T2 : notnull
{
    private readonly Dictionary<T1, T2> forward;
    private readonly Dictionary<T2, T1> reverse;

    public IReadonlyIndexer<T1, T2> Forward { get; }
    public IReadonlyIndexer<T2, T1> Reverse { get; }

    public int Count => forward.Count;

    public Map() : this(capacity: 4) { }
    public Map(int capacity)
    {
        (forward, reverse) = (new(capacity), new(capacity));

        Forward = new Indexer<T1, T2>(forward);
        Reverse = new Indexer<T2, T1>(reverse);
    }

    public Map(IReadOnlyList<T1> firstList, IReadOnlyList<T2> secondList) : this(capacity: firstList.Count)
    {
        if (firstList.Count != secondList.Count)
        {
            throw new ArgumentException(message: "firstList.Count != secondList.Count");
        }

        for (int i = 0; i < firstList.Count; i++)
        {
            T1 first = firstList[i];
            T2 second = secondList[i];

            Add(first, second);
        }
    }

    public void Add(T1 first, T2 second)
    {
        forward.Add(first, second);
        reverse.Add(second, first);
    }
}