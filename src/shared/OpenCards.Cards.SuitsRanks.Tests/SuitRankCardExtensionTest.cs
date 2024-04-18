namespace OpenCards.Cards.SuitsRanks.Tests;

public class SuitRankCardExtensionTest
{
    [Fact]
    public void Should_Beat_When_Same_Suit_But_Higher_Rank()
    {
        SuitRankCard attacker = new(Suit.Diamonds, Rank.Three);
        SuitRankCard defender = new(Suit.Diamonds, Rank.Two);

        Assert.True(attacker.CanBeat(defender));
    }
    [Fact]
    public void Should_Beat_When_Trump_Suit_But_Lower_Rank()
    {
        SuitRankCard attacker = new(Suit.Diamonds, Rank.Two);
        SuitRankCard defender = new(Suit.Clubs, Rank.Ace);

        SuitRankCard trump = new(Suit.Diamonds, Rank.King);

        Assert.True(attacker.CanBeat(defender, trump));
    }

    [Fact]
    public void Should_Not_Beat_When_Same_Suit_But_Lower_Rank()
    {
        SuitRankCard attacker = new(Suit.Diamonds, Rank.Two);
        SuitRankCard defender = new(Suit.Diamonds, Rank.Three);

        Assert.False(attacker.CanBeat(defender));
    }
    [Fact]
    public void Should_Not_Beat_When_Different_Suit_But_Higher_Rank()
    {
        SuitRankCard attacker = new(Suit.Clubs, Rank.Ace);
        SuitRankCard defender = new(Suit.Diamonds, Rank.Two);

        Assert.False(attacker.CanBeat(defender));
    }

    [Fact]
    public void Should_Return_MinRank()
    {
        SuitRankCard minRank = new(Suit.Clubs, Rank.Two);

        SuitRankCard[] cards = [
            new(Suit.Clubs, Rank.Ace),
            minRank,
            new(Suit.Clubs, Rank.King),
            new(Suit.Clubs, Rank.Jack),
        ];

        Assert.Equal(expected: minRank, cards.MinRank());
    }
    [Fact]
    public void Should_Return_MinRankBy()
    {
        SuitRankCard minRank = new(Suit.Clubs, Rank.Two);

        SuitRankCard[] cards = [
            new(Suit.Clubs, Rank.Ace),
            minRank,
            new(Suit.Clubs, Rank.King),
            new(Suit.Clubs, Rank.Jack),
        ];

        Assert.Equal(expected: minRank, cards.MinRankBy(Suit.Clubs));
    }
    [Fact]
    public void Should_Return_AnyRank()
    {
        SuitRankCard[] cards = [
            new(Suit.Clubs, Rank.Ace),
            new(Suit.Clubs, Rank.King),
            new(Suit.Clubs, Rank.Jack),
        ];

        Assert.True(cards.AnyRank(Rank.Ace));
    }
    [Fact]
    public void Should_Not_Return_AnyRank()
    {
        SuitRankCard[] cards = [
            new(Suit.Clubs, Rank.Ace),
            new(Suit.Clubs, Rank.King),
            new(Suit.Clubs, Rank.Jack),
        ];

        Assert.False(cards.AnyRank(Rank.Two));
    }
}