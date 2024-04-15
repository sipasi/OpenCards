namespace OpenCards.Cards.SuitsRanks.Tests;

public class SuitsRanksBuilderTest
{
    [Fact]
    public void Create_Full() => CreateTest(from: Rank.Two, to: Rank.Ace, SuitRankBuilder.Full());
    [Fact]
    public void Create_Medium() => CreateTest(from: Rank.Six, to: Rank.Ace, SuitRankBuilder.Medium());
    [Fact]
    public void Create_Small() => CreateTest(from: Rank.Seven, to: Rank.Ace, SuitRankBuilder.Small());

    private static void CreateTest(Rank from, Rank to, SuitRankCard[] deck)
    {
        const int zero_offset = 1;

        int suits = Enum.GetValues<Suit>().Length;
        int ranks = to - from + zero_offset;

        Assert.NotNull(deck);

        int expected_size = suits * ranks;

        Assert.Equal(expected_size, deck.Length);

        AssertRanksArgs args = new(deck, from, to);

        for (int suit = 0; suit < suits; suit++)
        {
            AssertRanks(args with
            {
                Suit = (Suit)suit,
                Skip = ranks * suit
            });
        }

        Assert.Equal(deck.Distinct().Count(), deck.Length);
    }

    private static void AssertRanks(AssertRanksArgs args)
    {
        const int zero_offset = 1;

        var (deck, from, to) = args;

        int ranks = to - from + zero_offset;

        var actual = deck.Skip(args.Skip).Take(ranks);

        var expected = Enumerable
            .Range((int)from, ranks)
            .Select(rank => new SuitRankCard(args.Suit, (Rank)rank));

        bool equal = expected.SequenceEqual(actual);

        Assert.True(equal);
    }

    private readonly record struct AssertRanksArgs(SuitRankCard[] Deck, Rank From, Rank To)
    {
        public SuitRankCard[] Deck { get; } = Deck;
        public Rank From { get; } = From;
        public Rank To { get; } = To;
        public Suit Suit { get; init; }
        public int Skip { get; init; }
    }
}
