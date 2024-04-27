using OpenCards.Durak.Events;
using OpenCards.Observables;

namespace OpenCards.Durak.ConsoleApp;

public class RoundExecutingObserver : IObserverAsync<RoundExecutingEvent>
{
    public ValueTask Notify(RoundExecutingEvent value)
    {
        GameDrawer.Draw(value.State);
        GameDrawer.DrawInputState(value.State.Queue);

        return ValueTask.CompletedTask;
    }
}
