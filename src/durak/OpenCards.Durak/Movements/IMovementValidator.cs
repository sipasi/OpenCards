using OpenCards.Durak.Movements.Results;

namespace OpenCards.Durak.Movements;

public interface IMovementValidator
{
    bool Validate(IPlayerActionResult result, MovementArguments arguments);
}
