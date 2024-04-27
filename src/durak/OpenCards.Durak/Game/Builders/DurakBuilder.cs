using Microsoft.Extensions.DependencyInjection;
using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Hands;
using OpenCards.Durak.Game.Settings;
using OpenCards.Durak.Movements;
using OpenCards.Durak.Players;
using OpenCards.Observables;
using OpenCards.States;

namespace OpenCards.Durak.Game.Builders;

public class DurakBuilder
{
    private readonly ObservableContainer observables = new();

    public DeckSize DeckSize { get; init; } = DeckSize.Medium;
    public required (string name, MoveType move)[] Players { get; init; }
    public required IPlayerMovementFactory MovementFactory { get; init; }

    public IStateMachine Build()
    {
        var (cards, players) = (CardsCreator.From(DeckSize), PlayerConverter.From(Players));

        var (deck, board, queue, storage) = GameCollections.Create(cards, players, boardSize: 6);

        DurakServiceCreator serviceCreator = new()
        {
            Board = board,
            Deck = deck,
            PlayerQueue = queue,
            PlayerStorage = storage,
            MovementFactory = MovementFactory,
            ObservableContainer = observables,
        };

        ServiceProvider provider = serviceCreator.Create();

        return provider.GetService<IStateMachine>()!;
    }

    public DurakBuilder RegisterEvent<T>(IObserverAsync<T> observer) where T : class
    {
        observables.Register(observer);

        return this;
    }
}

file static class CardsCreator
{
    public static SuitRankCard[] From(DeckSize size) => size switch
    {
        DeckSize.Small => SuitRankBuilder.Small(),
        DeckSize.Medium => SuitRankBuilder.Medium(),
        DeckSize.Full => SuitRankBuilder.Full(),
        DeckSize.DoubleMedium => SuitRankBuilder.Medium().Repeat(times: 2),
        DeckSize.DoubleFull => SuitRankBuilder.Full().Repeat(times: 2),
        _ => SuitRankBuilder.Medium(),
    };
}

file static class PlayerConverter
{
    public static IPlayer[] From((string name, MoveType move)[] infos) => infos
        .Select(AsPlayer)
        .ToArray();

    private static IPlayer AsPlayer((string name, MoveType move) info, int index) => new Player(
        id: index,
        name: info.name,
        moveType: info.move,
        hand: new Hand<SuitRankCard>()
    );
}