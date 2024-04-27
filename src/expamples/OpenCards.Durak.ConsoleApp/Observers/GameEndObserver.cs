using OpenCards.Durak.Events;
using OpenCards.Observables;

namespace OpenCards.Durak.ConsoleApp;

public class GameEndObserver : IObserverAsync<GameEndEvent>
{
    public ValueTask Notify(GameEndEvent value)
    {
        GameDrawer.Draw(value.State);

        Console.WriteLine();

        var storage = value.State.Storage;
        var active = storage.Active;

        if (active.Count == 0)
        {
            GameDrawer.DrawLineColor(ConsoleColor.Gray, $"Game is draw");

            Console.WriteLine();
        }
        else if (active.Count == 1)
        {
            GameDrawer.DrawLineColor(ConsoleColor.Red, $"Loser is {active[0].Name}");

            GameDrawer.DrawLineColor(ConsoleColor.Green, $"Winner is {string.Join(" and ", storage.Removed.Select(static player => player.Name))}");

            Console.WriteLine();
        }

        return ValueTask.CompletedTask;
    }
}
