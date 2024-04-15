namespace OpenCards.Collections.Players;

public class PlayerStorage<T>(IReadOnlyList<T> players) : IPlayerStorage<T>
{
    private readonly IReadOnlyList<T> players = players;

    private readonly List<T> active = new(players);
    private readonly List<T> removed = new(players.Count);

    public int Count => active.Count;

    public IReadOnlyList<T> All => players;
    public IReadOnlyList<T> Active => active;
    public IReadOnlyList<T> Removed => removed;

    public T this[int index] => active[index];

    public int RemoveAll(Predicate<T> match)
    {
        int count = 0;

        for (int i = active.Count - 1; i >= 0; i--)
        {
            T player = active[i];

            if (match.Invoke(player) == false)
            {
                continue;
            }

            active.RemoveAt(i);

            removed.Add(player);

            count++;
        }

        return count;
    }

    public void Restore()
    {
        active.Clear();
        removed.Clear();

        active.AddRange(players);
    }
}