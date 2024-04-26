using OpenCards.Durak.Game;
using OpenCards.Durak.Rounds.Results;

namespace OpenCards.Durak.Events;

public record RoundExecutedEvent(IReadonlyGameState State, IRoundResult Move) : IGameEvent;
