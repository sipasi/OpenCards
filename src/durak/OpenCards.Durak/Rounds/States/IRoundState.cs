namespace OpenCards.Durak.Rounds.States;

public interface IRoundState
{
    void Execute(RoundSharedData shared);
}
