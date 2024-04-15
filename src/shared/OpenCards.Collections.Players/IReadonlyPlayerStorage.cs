namespace OpenCards.Collections.Players;

public interface IReadonlyPlayerStorage<out T>
{
    IReadOnlyList<T> All { get; }
    IReadOnlyList<T> Active { get; }
    IReadOnlyList<T> Removed { get; }
}
