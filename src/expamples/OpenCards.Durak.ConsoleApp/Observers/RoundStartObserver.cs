using OpenCards.Durak.Events;
using OpenCards.Observables;

namespace OpenCards.Durak.ConsoleApp;

public class RoundStartObserver : IObserverAsync<RoundStartEvent>
{
    public async ValueTask Notify(RoundStartEvent value)
    {
        GameDrawer.Draw(value.State);

        GameDrawer.DrawColor(ConsoleColor.Blue, $"Shuffle deck({value.State.Deck.Count}) ...");

        await Task.Delay(500);
    }
}
