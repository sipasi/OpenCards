using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Hands;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Game;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.ConsoleApp;

public static class GameDrawer
{
    public static void Draw(IReadonlyGameState state)
    {
        Clear();

        var (deck, board) = (state.Deck, state.Board);

        DrawDeck(deck);

        Console.WriteLine();

        DrawPlayers(state);

        Console.WriteLine();

        DrawBoard(board);
    }

    public static void DrawInputState(IReadonlyPlayerQueue<IReadonlyPlayer> queue)
    {
        IReadonlyPlayer current = queue.Current;

        string message = current.MoveType switch
        {
            MoveType.Local => $"Enter from 0 to {current.Hand.Count - 1} or press p to pass: ",
            MoveType.Bot => "Wait, Bot is Thinking",
            MoveType.Server => "Wait for server side",
            _ => throw new NotImplementedException(),
        };

        Console.WriteLine();

        DrawColor(ConsoleColor.Blue, message);
    }

    private static void DrawDeck(IReadonlyDurakDeck deck)
    {
        Console.WriteLine($"{deck.Trump} - {deck.Count}");
    }
    private static void DrawBoard(IReadonlyBoard<SuitRankCard> board)
    {
        for (int i = 0; i < board.All.Count; i++)
        {
            SuitRankCard data = board.All[i];

            Console.WriteLine(data);
        }
    }

    private static void DrawPlayers(IReadonlyGameState state)
    {
        foreach (var player in state.Storage.Active)
        {
            var (id, name, hand) = (player.Id, player.Name, player.Hand);

            IReadonlyPlayerQueue<IReadonlyPlayer> queue = state.Queue;

            bool current = id == queue.Current.Id;

            string star = current ? "*" : " ";
            string defender = id == queue.Defender.Id ? "🛡" : " ";

            ConsoleColor color = current ? ConsoleColor.DarkGreen : ConsoleColor.DarkGray;

            DrawLineColor(color, $"{star}{defender} {name} ({hand.Count}): ");

            DrawPlayerHand(state, player, current, hide: false);
        }
    }
    private static void DrawPlayerHand(IReadonlyGameState state, IReadonlyPlayer player, bool current, bool hide)
    {
        var (name, moveType, hand) = (player.Name, player.MoveType, player.Hand);

        foreach (var (card, text) in HandAsStrings(hand, secure: hide))
        {
            if (current is false)
            {
                Console.WriteLine(text);

                continue;
            }

            if (state.Queue.IsDefenderQueue)
            {
                SuitRankCard last = state.Board.Attacks.Last();

                if (card.CanBeat(last, state.Deck.Trump))
                {
                    DrawLineColor(ConsoleColor.Yellow, text);
                }
                else
                {
                    Console.WriteLine(text);
                }

                continue;
            }

            if (state.Board.IsEmpty is false)
            {
                if (state.Board.All.Any(card.EqualRank))
                {
                    DrawLineColor(ConsoleColor.Yellow, text);
                }
                else
                {
                    Console.WriteLine(text);
                }
            }
            else
            {
                Console.WriteLine(text);
            }
        }
    }

    private static IEnumerable<(SuitRankCard, string)> HandAsStrings(IReadOnlyHand<SuitRankCard> hand, bool secure = true)
    {
        var pattern = hand.Select((card, index) => secure switch
        {
            true => (card, "*"),
            false => (card, $"    ({index}) {card}")
        });

        // Spade = U+2660, Heart = U+2665, Diamond = U+2666, Heart = U+2663

        return pattern;
    }

    public static void DrawLineColor(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;

        Console.WriteLine(text);

        Console.ResetColor();
    }
    public static void DrawColor(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;

        Console.Write(text);

        Console.ResetColor();
    }

    public static void Clear()
    {
        Console.Clear();
        Console.ResetColor();
    }
}
