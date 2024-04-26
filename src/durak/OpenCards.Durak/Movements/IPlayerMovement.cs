using OpenCards.Durak.Movements.Results;

namespace OpenCards.Durak.Movements;

public interface IPlayerMovement
{
    ValueTask<IPlayerActionResult> Make(MovementArguments arguments);
}
