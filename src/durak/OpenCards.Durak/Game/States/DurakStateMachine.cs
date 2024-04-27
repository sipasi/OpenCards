using OpenCards.States;

namespace OpenCards.Durak.Game.States;

public sealed class DurakStateMachine(IReadonlyGameState info, IStateContainer container) : IStateMachine
{
    private IStateAsync current = container.Get<GameStartState>();

    public async ValueTask Execute()
    {
        current = await current.Execute(info, container);
    }
}
