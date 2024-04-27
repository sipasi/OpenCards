using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Game;

public record ReadonlyGameState(
    IReadonlyDurakDeck Deck,
    IReadonlyBoard<SuitRankCard> Board,
    IReadonlyPlayerQueue<IReadonlyPlayer> Queue,
    IReadonlyPlayerStorage<IReadonlyPlayer> Storage) : IReadonlyGameState;