using OpenCards.Durak.Dealers;
using OpenCards.Durak.Events;
using OpenCards.Durak.Rounds;
using OpenCards.Observables;
using OpenCards.States;

namespace OpenCards.Durak.Game.States;

public class RoundStartState(IRoundSystem system, ICardDealer dealer, IObservableContainer observables) : IStateAsync
{
    public async ValueTask<IStateAsync> Execute(IReadonlyGameState info, IStateContainer container)
    {
        system.NewRound();

        dealer.DealCards();

        await observables.NotifyAsync<RoundStartEvent>(new(info));

        return container.Get<RoundExecuteState>();
    }
}
