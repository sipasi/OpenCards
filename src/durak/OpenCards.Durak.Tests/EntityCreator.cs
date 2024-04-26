using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Hands;
using OpenCards.Collections.Indexes;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Elimenators;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Tests;

public class EntityCreator
{
    /// <returns>deck of <see cref="Suit.Clubs"/> from <see cref="Rank.Two"/> to <see cref="Rank.Five"/></returns>
    public static (SuitRankCard[], DecrementalIndexes, DurakDeck) CreateDeck()
    {
        SuitRankCard[] cards = [
            new (Suit.Clubs, Rank.Two),
            new (Suit.Clubs, Rank.Three),
            new (Suit.Clubs, Rank.Four),
            new (Suit.Clubs, Rank.Five),
        ];

        DecrementalIndexes indexes = new(count: cards.Length);

        return (cards, indexes, new(cards, indexes));
    }

    public static PlayerStorage<IPlayer> CreatePlayerStorage(IEnumerable<SuitRankCard[]> hands)
    {
        IPlayer[] players = hands
            .Select((hand, index) => CreatePlayer(index, hand))
            .ToArray();

        PlayerStorage<IPlayer> storage = new(players);

        PlayerElimenator elimenator = new(storage);

        return storage;
    }

    public static IPlayer CreatePlayer(SuitRankCard[] cards) => CreatePlayer(0, cards);
    public static IPlayer CreatePlayer(int id, SuitRankCard[] cards)
    {
        Hand<SuitRankCard> hand = [.. cards];

        Player player = new(id: id, $"Bot {id}", MoveType.Bot, hand);

        return player;
    }
}