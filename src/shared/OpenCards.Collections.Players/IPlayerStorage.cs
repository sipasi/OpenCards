namespace OpenCards.Collections.Players;

public interface IPlayerStorage<out T> : IReadonlyPlayerStorage<T>
{
    int RemoveAll(Predicate<T> match);

    void Restore();
}