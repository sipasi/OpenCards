using OpenCards.Durak.Game;

namespace OpenCards.Durak.Events;

public record GameStartEvent(IReadonlyGameState State) : IGameEvent;
