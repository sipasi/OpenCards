using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Game;

public interface IReadonlyGameState
{
    IReadonlyDurakDeck Deck { get; }
    IReadonlyBoard<SuitRankCard> Board { get; }
    IReadonlyPlayerQueue<IReadonlyPlayer> Queue { get; }
    IReadonlyPlayerStorage<IReadonlyPlayer> Storage { get; }
}
