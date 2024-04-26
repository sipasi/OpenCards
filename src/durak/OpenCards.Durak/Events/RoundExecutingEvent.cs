using OpenCards.Durak.Game;

namespace OpenCards.Durak.Events;

public record RoundExecutingEvent(IReadonlyGameState State) : IGameEvent;
