using OpenCards.Durak.Game;

namespace OpenCards.Durak.Events;

public interface IGameEvent
{
    IReadonlyGameState State { get; init; }
}
