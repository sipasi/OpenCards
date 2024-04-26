using OpenCards.Durak.Tests;

namespace OpenCards.Durak.Collections.Decks.Tests;

public class DeckTest
{
    [Fact]
    public void Should_Not_Same_Sequence_As_Origin()
    {
        var (cards, _, deck) = EntityCreator.CreateDeck();

        deck.Shuffle();

        Assert.False(deck.SequenceEqual(cards));
    }

    [Fact]
    public void Should_Trump_Not_Null_After_Shuffel()
    {
        var (_, _, deck) = EntityCreator.CreateDeck();

        Assert.Null(deck.Trump);

        deck.Shuffle();

        Assert.NotNull(deck.Trump);
    }
}
