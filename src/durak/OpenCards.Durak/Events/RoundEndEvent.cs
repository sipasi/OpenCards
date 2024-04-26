using OpenCards.Durak.Game;

namespace OpenCards.Durak.Events;

public record RoundEndEvent(IReadonlyGameState State) : IGameEvent;