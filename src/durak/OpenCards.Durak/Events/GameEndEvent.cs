using OpenCards.Durak.Game;

namespace OpenCards.Durak.Events;

public record GameEndEvent(IReadonlyGameState State) : IGameEvent;
