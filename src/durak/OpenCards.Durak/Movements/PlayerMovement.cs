using OpenCards.Durak.Movements.Results;

namespace OpenCards.Durak.Movements;

public abstract class PlayerMovement(IMovementValidator validator) : IPlayerMovement
{
    public async ValueTask<IPlayerActionResult> Make(MovementArguments arguments)
    {
        IPlayerActionResult result = await MakeMove(arguments);

        if (validator.Validate(result, arguments))
        {
            return result;
        }

        return result switch
        {
            PlayerWronged wronged => wronged,
            PlayerMoved moved => new PlayerWronged(moved.Card),
            _ => new PlayerWronged(),
        };
    }

    protected abstract ValueTask<IPlayerActionResult> MakeMove(MovementArguments arguments);
}
