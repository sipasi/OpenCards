using OpenCards.Durak.Game.Builders;
using OpenCards.Durak.Game.Settings;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.ConsoleApp;

internal static class DurakConsoleBuilder
{
    public static DurakBuilder Init() => new()
    {
        DeckSize = AskDeckSize(),
        Players = AskPlayers(),
        MovementFactory = new ConsoleMovement()
    };
    public static DurakBuilder Default() => new()
    {
        DeckSize = DeckSize.Medium,
        Players = [("You", MoveType.Local), ("Bot", MoveType.Bot)],
        MovementFactory = new ConsoleMovement()
    };


    private static DeckSize AskDeckSize() => Ask<DeckSize>(Enum.GetValues<DeckSize>(), "Enter deck size: ", static size => $"{size}({(int)size})");
    private static (string, MoveType)[] AskPlayers()
    {
        int count = Ask<int>([2, 3, 4], "Player count: ", static size => size.ToString());

        var players = new (string, MoveType)[count];

        players[0] = ("You", MoveType.Local);

        for (int i = 1; i < count; i++)
        {
            players[i] = ($"Bot: {i}", MoveType.Bot);
        }

        return players;
    }

    private static T Ask<T>(ReadOnlySpan<T> values, string title, Func<T, string> formatter)
    {
        while (true)
        {
            Console.Clear();

            int index = 0;

            foreach (var item in values)
            {
                Console.WriteLine($"{index++}: {formatter.Invoke(item)}");
            }

            Console.WriteLine();

            Console.Write(title);

            string? line = Console.ReadLine();

            if (int.TryParse(line, out int result) && result >= 0 && result < values.Length)
            {
                return values[result];
            }
        }
    }
}