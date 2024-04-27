using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Hands;
using OpenCards.Durak.Movements;
using OpenCards.Durak.Movements.Results;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.ConsoleApp;

public sealed class LocalMove(IMovementValidator validator) : PlayerMovement(validator)
{
    protected override ValueTask<IPlayerActionResult> MakeMove(MovementArguments arguments)
    {
        var (player, _, board, _) = arguments;

        string? line = Console.ReadLine() ?? throw new NullReferenceException();

        IPlayerActionResult move = GetMove(player, line, board);

        return move.AsValueTask();
    }

    public static IPlayerActionResult GetMove(IReadonlyPlayer current, string? input, IReadonlyBoard<SuitRankCard> board)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return new PlayerWronged();
        }

        if (input is "p")
        {
            return board.IsEmpty
                ? new PlayerWronged()
                : new PlayerPassed();
        }

        if (int.TryParse(input, out var result) && current.Hand.InRange(result))
        {
            return new PlayerMoved(current.Hand[result]);
        }

        return new PlayerWronged();
    }
}
