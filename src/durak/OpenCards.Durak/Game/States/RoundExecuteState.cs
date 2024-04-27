using OpenCards.Durak.Events;
using OpenCards.Durak.Rounds;
using OpenCards.Durak.Rounds.Results;
using OpenCards.Observables;
using OpenCards.States;

namespace OpenCards.Durak.Game.States;

public class RoundExecuteState(IRoundSystem rounds, IObservableContainer observables) : IStateAsync
{
    public async ValueTask<IStateAsync> Execute(IReadonlyGameState info, IStateContainer container)
    {
        await observables.NotifyAsync<RoundExecutingEvent>(new(info));

        IRoundResult round = await rounds.Execute();

        await observables.NotifyAsync<RoundExecutedEvent>(new(info, round));

        return round.Completed()
            ? container.Get<RoundEndState>()
            : this;
    }
}
