using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Indexes;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Game.Builders;

public sealed class GameCollections
{
    public required IDurakDeck Deck { get; init; }
    public required IBoard<SuitRankCard> Board { get; init; }
    public required IPlayerQueue<IPlayer> Queue { get; init; }
    public required IPlayerStorage<IPlayer> Storage { get; init; }

    public void Deconstruct(out IDurakDeck deck, out IBoard<SuitRankCard> board, out IPlayerQueue<IPlayer> queue, out IPlayerStorage<IPlayer> storage)
    {
        deck = Deck;
        board = Board;
        queue = Queue;
        storage = Storage;
    }

    public static GameCollections Create(IReadOnlyList<SuitRankCard> datas, IPlayer[] players, int boardSize)
    {
        DurakDeck deck = new(datas, new DecrementalIndexes(datas.Count));

        Board<SuitRankCard> board = new(rowSize: boardSize);

        PlayerStorage<IPlayer> playerStorage = new(players);
        PlayerQueue<IPlayer> playerQueue = new(playerStorage);

        return new()
        {
            Deck = deck,
            Board = board,
            Queue = playerQueue,
            Storage = playerStorage
        };
    }
}
