using OpenCards.Durak.Game;

namespace OpenCards.Durak.Events;

public record RoundStartEvent(IReadonlyGameState State) : IGameEvent;
