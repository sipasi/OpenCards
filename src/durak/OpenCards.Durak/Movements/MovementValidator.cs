using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Extensions;
using OpenCards.Durak.Collections.Boards;
using OpenCards.Durak.Movements.Results;

namespace OpenCards.Durak.Movements;

public class MovementValidator : IMovementValidator
{
    public static IMovementValidator Default { get; } = new MovementValidator();

    public bool Validate(IPlayerActionResult result, MovementArguments arguments)
    {
        var (_, deck, board, action) = arguments;

        if (result.Moved(out var card))
        {
            if (board.All.IsEmpty())
            {
                return true;
            }

            if (action is PlayerActionType.Attack or PlayerActionType.Toss)
            {
                return board.ContainsRank(card);
            }

            if (action is PlayerActionType.Defend)
            {
                var last = board.Attacks.Last()!;

                return card.CanBeat(last, deck.Trump);
            }
        }

        if (result.Passed())
        {
            return board.IsEmpty == false;
        }

        return true;
    }
}
