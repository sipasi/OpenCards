namespace OpenCards.Collections.Decks;

public interface IReadonlyDeck<T> : IReadOnlyCollection<T>
{
    /// <summary>
    /// Gets the maximum number of elements the deck can hold.
    /// </summary> 
    int Capacity { get; }
    bool IsEmpty { get; }
}