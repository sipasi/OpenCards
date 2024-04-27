using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Movements;
using OpenCards.Durak.Movements.Results;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Rounds;

public class Round(IPlayerMovementFactory movementFactory, IPlayerQueue<IPlayer> queue, IPlayerStorage<IPlayer> storage, IReadonlyDurakDeck deck, IBoard<SuitRankCard> board) : IRound
{
    private readonly List<IPlayerActionResult> moves = new(capacity: 12);

    private readonly RoundStateDefiner stateDefiner = new(queue, storage, board);

    private readonly RoundSharedData shared = new();

    public IRoundSharedData Data => shared;

    public async ValueTask<IPlayerActionResult> Execute()
    {
        IPlayerActionResult action = await WaitPlayerMove();

        if (action.Wronged())
        {
            return action;
        }

        moves.Add(action);

        var state = stateDefiner.GetState(shared, action);

        state.Execute(shared);

        return action;
    }

    public ValueTask<IPlayerActionResult> WaitPlayerMove()
    {
        IPlayerMovement movement = movementFactory.Get(queue.Current.MoveType);

        return movement.Make(new MovementArguments
        {
            Current = queue.Current,
            Deck = deck,
            Board = board,
            ActionType = GetActionType(),
        });
    }

    private PlayerActionType GetActionType()
    {
        if (queue.IsDefenderQueue)
        {
            return PlayerActionType.Defend;
        }

        return shared.IsDefenderPassed
            ? PlayerActionType.Toss
            : PlayerActionType.Attack;
    }
}
