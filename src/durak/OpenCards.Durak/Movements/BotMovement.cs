using OpenCards.Durak.Movements.Results;

namespace OpenCards.Durak.Movements;

public abstract class BotMovement(IMovementValidator validator) : PlayerMovement(validator)
{
    protected sealed override ValueTask<IPlayerActionResult> MakeMove(MovementArguments arguments) => arguments switch
    {
        { ActionType: PlayerActionType.Attack, Board.IsEmpty: true } => FirstAttack(arguments).AsValueTask(),
        { ActionType: PlayerActionType.Attack, Board.IsEmpty: false } => NextAttack(arguments).AsValueTask(),
        { ActionType: PlayerActionType.Defend } => Defend(arguments).AsValueTask(),
        { ActionType: PlayerActionType.Toss } => Toss(arguments).AsValueTask(),
        _ => throw new NotImplementedException($"Can't handle [{arguments.ActionType}] type")
    };

    public abstract IPlayerActionResult FirstAttack(MovementArguments arguments);
    public abstract IPlayerActionResult NextAttack(MovementArguments arguments);

    public abstract IPlayerActionResult Defend(MovementArguments arguments);

    public abstract IPlayerActionResult Toss(MovementArguments arguments);
}
