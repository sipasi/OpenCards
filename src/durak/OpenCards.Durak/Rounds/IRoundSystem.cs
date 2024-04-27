using OpenCards.Durak.Rounds.Results;

namespace OpenCards.Durak.Rounds;

public interface IRoundSystem
{
    void NewRound();

    ValueTask<IRoundResult> Execute();
}