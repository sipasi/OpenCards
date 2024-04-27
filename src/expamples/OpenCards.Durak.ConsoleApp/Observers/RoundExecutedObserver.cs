using OpenCards.Durak.Events;
using OpenCards.Durak.Players;
using OpenCards.Observables;

namespace OpenCards.Durak.ConsoleApp;

public class RoundExecutedObserver : IObserverAsync<RoundExecutedEvent>
{
    public async ValueTask Notify(RoundExecutedEvent value)
    {
        GameDrawer.Draw(value.State);

        if (value.State.Queue.Current.MoveType is MoveType.Bot)
        {
            await Task.Delay(500);
        }
    }
}