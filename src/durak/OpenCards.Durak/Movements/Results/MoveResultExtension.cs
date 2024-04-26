using System.Diagnostics.CodeAnalysis;
using OpenCards.Cards.SuitsRanks;

namespace OpenCards.Durak.Movements.Results;

public static class MoveResultExtension
{
    public static bool Moved(this IPlayerActionResult result) => result is PlayerMoved;
    public static bool Moved(this IPlayerActionResult result, [NotNullWhen(true)] out SuitRankCard? card)
        => (card = (result as PlayerMoved)?.Card) is not null;
    public static bool Passed(this IPlayerActionResult result) => result is PlayerPassed;
    public static bool Wronged(this IPlayerActionResult result) => result is PlayerWronged;

    public static bool TryCast<T>(this IPlayerActionResult result, out T? value)
        where T : class, IPlayerActionResult => (value = result as T) is not null;

    public static ValueTask<IPlayerActionResult> AsValueTask(this IPlayerActionResult result) => ValueTask.FromResult(result);
}