using OpenCards.Durak.Events;
using OpenCards.Observables;

namespace OpenCards.Durak.ConsoleApp;

public class GameStartObserver : IObserverAsync<GameStartEvent>
{
    public ValueTask Notify(GameStartEvent value)
    {
        GameDrawer.Draw(value.State);

        return ValueTask.CompletedTask;
    }
}
