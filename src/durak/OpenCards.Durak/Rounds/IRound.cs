using OpenCards.Durak.Movements.Results;

namespace OpenCards.Durak.Rounds;

public interface IRound
{
    public IRoundSharedData Data { get; }

    ValueTask<IPlayerActionResult> Execute();
}
