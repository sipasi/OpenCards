using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Movements;

public readonly record struct MovementArguments(
    IReadonlyPlayer Current,
    IReadonlyDurakDeck Deck,
    IReadonlyBoard<SuitRankCard> Board,
    PlayerActionType ActionType);
