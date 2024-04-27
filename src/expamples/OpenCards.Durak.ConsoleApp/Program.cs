using System.Text;

using OpenCards.Durak.StateMachines;
using OpenCards.States;

namespace OpenCards.Durak.ConsoleApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.InputEncoding = Encoding.GetEncoding(1200);
        Console.OutputEncoding = Encoding.UTF8;

        IStateMachine game = CreateGame();

        await PlayStateMachine(game);
    }

    public static IStateMachine CreateGame() => DurakConsoleBuilder
        .Default()

        .RegisterEvent(new GameStartObserver())
        .RegisterEvent(new GameEndObserver())
        .RegisterEvent(new RoundStartObserver())
        .RegisterEvent(new RoundExecutingObserver())
        .RegisterEvent(new RoundExecutedObserver())

        .Build();


    public static async ValueTask PlayStateMachine(IStateMachine game)
    {
        while (true)
        {
            await game.Execute();
        }
    }
}
