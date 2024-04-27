using OpenCards.Durak.Events;
using OpenCards.Observables;
using OpenCards.States;

namespace OpenCards.Durak.Game.States;

public class GameEndState(IObservableContainer observables) : IStateAsync
{
    public async ValueTask<IStateAsync> Execute(IReadonlyGameState info, IStateContainer container)
    {
        await observables.NotifyAsync<GameEndEvent>(new(info));

        throw new NotImplementedException();
    }
}