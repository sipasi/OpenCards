namespace OpenCards.Durak.Rounds.States;

public class RoundStates(IEnumerable<IRoundState> states) : IRoundState
{
    public void Execute(RoundSharedData shared)
    {
        foreach (var state in states)
        {
            state.Execute(shared);
        }
    }
}
