using OpenCards.Durak.Players;

namespace OpenCards.Durak.Movements;

public interface IPlayerMovementFactory
{
    IPlayerMovement Get(MoveType move);
}
