using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Extensions;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Players;
using OpenCards.Durak.Tests;

namespace OpenCards.Durak.Dealers.Tests;

public class CardDelaerTest
{
    [Fact]
    public void Should_DealCards()
    {
        DurakDeck deck = new(SuitRankBuilder.Medium());

        PlayerStorage<IPlayer> storage = EntityCreator.CreatePlayerStorage(hands: [[], []]);
        PlayerQueue<IPlayer> queue = new(storage);

        CardDealer dealer = new(deck, queue, storage);

        Assert.True(storage.Active.All(player => player.Hand.IsEmpty()));

        dealer.DealCards();

        Assert.True(storage.Active.All(player => player.Hand.IsNotEmpty()));
    }
}