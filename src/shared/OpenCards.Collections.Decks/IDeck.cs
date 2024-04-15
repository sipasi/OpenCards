namespace OpenCards.Collections.Decks;

public interface IDeck<T> : IReadonlyDeck<T>
{
    /// <summary>
    /// Draws a card from the deck
    /// </summary>
    /// <returns>The card drawn from the deck, or default if the deck is empty</returns>
    T? Draw();

    /// <summary>
    /// Returning deck to original state
    /// </summary>
    void Reset();

    /// <summary>
    /// Resets the deck and shuffling the cards
    /// </summary>
    void Shuffle();
}
