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
}
