using System.Collections;

namespace OpenCards.Collections.Boards;

public class Board<T>(int rowSize) : IBoard<T>
{
    private readonly List<T> all = new(rowSize * Indexes.count);
    private readonly List<T>[] places = [new(rowSize), new(rowSize)];

    private readonly int rowSize = rowSize;

    private int index;

    public IReadOnlyList<T> All => all;
    public IReadOnlyList<T> Attacks => places[Indexes.attacks];
    public IReadOnlyList<T> Defends => places[Indexes.defends];

    public bool IsAttacksPlace => index == Indexes.attacks;
    public bool IsDefendsPlace => index == Indexes.defends;

    public bool IsEmpty => Count == 0;
    public bool IsFull => all.Count == rowSize * 2;
    public bool IsAttacksFull => Attacks.Count == rowSize;
    public bool IsDefendsFull => Defends.Count == rowSize;

    public int Count => all.Count;

    public void Add(T item)
    {
        List<T> place = places[index];

        if (place.Count == rowSize)
        {
            throw new IndexOutOfRangeException();
        }
        if (all.Contains(item))
        {
            throw new ArgumentException($"Board contains: {item}");
        }

        index = (index + 1) % Indexes.count;

        all.Add(item);
        place.Add(item);
    }

    public void AddToAttacks(T item)
    {
        index = Indexes.attacks;

        Add(item);
    }
    public void AddToDefends(T item)
    {
        index = Indexes.defends;

        Add(item);
    }

    public void Clear()
    {
        foreach (var place in places)
        {
            place.Clear();
        }

        all.Clear();

        index = 0;
    }

    public List<T>.Enumerator GetEnumerator() => all.GetEnumerator();

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => all.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => all.GetEnumerator();
}

file readonly struct Indexes
{
    public const int count = 2;
    public const int defends = 1;
    public const int attacks = 0;
}