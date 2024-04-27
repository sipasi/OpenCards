using OpenCards.Durak.Movements;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.ConsoleApp;

public class ConsoleMovement : IPlayerMovementFactory
{
    public IPlayerMovement Get(MoveType move) => move switch
    {
        MoveType.Bot => new SimpleBotMove(MovementValidator.Default),
        MoveType.Local => new LocalMove(MovementValidator.Default),
        _ => throw new NotImplementedException($"{move} has not implemented")
    };
}
