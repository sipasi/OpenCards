using System.Collections;

using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Tests;

namespace OpenCards.Durak.Players.Tests;

public class PlayerDefinerTest
{
    [Fact]
    public void Should_Return_Player_With_Smallest_Trump()
    {
        Data data = Data.Create();

        Assert.Equal(data.WithSmallestTrump, data.Definer.GetWithSmallestTrump(null!));
    }

    [Fact]
    public void Should_Set_First_Player_In_Queue()
    {
        Data data = Data.Create();

        data.Definer.SetFirstPlayer();

        Assert.Equal(data.WithSmallestTrump, data.Queue.Attacker);
        Assert.Equal(data.WithHighestTrump, data.Queue.Defender);
    }
}

file readonly struct Data
{
    public required IPlayer WithSmallestTrump { get; init; }
    public required IPlayer WithHighestTrump { get; init; }

    public required TestDurakDeck Deck { get; init; }

    public required PlayerStorage<IPlayer> Storage { get; init; }
    public required PlayerQueue<IPlayer> Queue { get; init; }
    public required PlayerDefiner Definer { get; init; }

    public static Data Create()
    {
        SuitRankCard trump = new(Suit.Clubs, Rank.Jack);
        TestDurakDeck deck = new(trump);

        IPlayer withSmallestTrump = EntityCreator.CreatePlayer(
            [
                new SuitRankCard(Suit.Hearts, Rank.Two),
                new SuitRankCard(Suit.Hearts, Rank.Two),
                new SuitRankCard(Suit.Clubs, Rank.Five),
                new SuitRankCard(Suit.Hearts, Rank.Two),
                new SuitRankCard(Suit.Hearts, Rank.Two),
            ]
        );
        IPlayer withHighestTrump = EntityCreator.CreatePlayer(
            [
                new SuitRankCard(Suit.Diamonds, Rank.Two),
                new SuitRankCard(Suit.Diamonds, Rank.Two),
                new SuitRankCard(Suit.Clubs, Rank.Ace),
                new SuitRankCard(Suit.Diamonds, Rank.Two),
                new SuitRankCard(Suit.Diamonds, Rank.Two),
            ]
        );

        PlayerStorage<IPlayer> storage = new([withSmallestTrump, withHighestTrump]);

        PlayerQueue<IPlayer> queue = new(storage);

        PlayerDefiner playerDefiner = new(deck, queue, storage);

        return new()
        {
            Deck = deck,
            WithHighestTrump = withHighestTrump,
            WithSmallestTrump = withSmallestTrump,
            Queue = queue,
            Storage = storage,
            Definer = playerDefiner,
        };
    }
}

file class TestDurakDeck(SuitRankCard trump) : IReadonlyDurakDeck
{
    public SuitRankCard Trump => trump;

    public int Capacity { get; }
    public bool IsEmpty { get; }
    public int Count { get; }

    public IEnumerator<SuitRankCard> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
