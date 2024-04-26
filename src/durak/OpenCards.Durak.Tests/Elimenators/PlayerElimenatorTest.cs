using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Players;
using OpenCards.Durak.Players;
using OpenCards.Durak.Tests;

namespace OpenCards.Durak.Elimenators.Tests;

public class PlayerElimenatorTest
{
    [Fact]
    public void Should_Remove_All_Empty_Players()
    {
        PlayerStorage<IPlayer> storage = EntityCreator.CreatePlayerStorage([
            [],
            [new SuitRankCard(Suit.Clubs, Rank.Two)]
        ]);

        PlayerElimenator elimenator = new(storage);

        Assert.Equal(expected: 2, actual: storage.Count);

        elimenator.EliminateEmpty();

        Assert.Equal(expected: 1, actual: storage.Count);
    }
}