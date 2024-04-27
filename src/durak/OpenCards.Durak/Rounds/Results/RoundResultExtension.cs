using System.Diagnostics.CodeAnalysis;

namespace OpenCards.Durak.Rounds.Results;

public static class RoundResultExtension
{
    public static bool Executed(this IRoundResult result) => result is RoundExecuted;
    public static bool Completed(this IRoundResult result) => result is RoundCompleted;
    public static bool NotCompleted(this IRoundResult result) => result is not RoundCompleted;

    public static bool TryCast<T>(this IRoundResult result, [NotNullWhen(true)] out T? value)
        where T : class, IRoundResult => (value = result as T) is not null;

    public static ValueTask<IRoundResult> AsValueTask(this IRoundResult result) => ValueTask.FromResult(result);
}
