namespace OpenCards.Collections.Boards;

/// <summary>
/// Represents a readonly game board.
/// </summary>
public interface IBoard<T> : IReadonlyBoard<T>
{
    void Add(T item);
    void AddToAttacks(T item);
    void AddToDefends(T item);
    void Clear();
}
