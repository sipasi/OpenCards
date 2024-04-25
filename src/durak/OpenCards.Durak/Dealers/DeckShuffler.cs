using OpenCards.Durak.Collections.Decks;

namespace OpenCards.Durak.Dealers;

public class DeckShuffler(IDurakDeck deck) : IDeckShuffler
{
    public void NewGameShuffle() => deck.Shuffle();
}
