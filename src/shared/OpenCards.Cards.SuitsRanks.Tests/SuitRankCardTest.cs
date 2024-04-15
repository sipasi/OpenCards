namespace OpenCards.Cards.SuitsRanks.Tests;

public class SuitRankCardTest
{
    [Fact]
    public void Should_Equal_When_Same_Suit_And_Rank()
    {
        SuitRankCard attacker = new(Suit.Diamonds, Rank.Two);
        SuitRankCard defender = new(Suit.Diamonds, Rank.Two);

        Assert.Equal(attacker, defender);
    }

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
}