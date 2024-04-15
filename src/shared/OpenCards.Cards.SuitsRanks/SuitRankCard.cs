namespace OpenCards.Cards.SuitsRanks;

public record SuitRankCard(Suit Suit, Rank Rank)
{
    public bool EqualSuit(SuitRankCard other) => Suit == other.Suit;
    public bool EqualRank(SuitRankCard other) => Rank == other.Rank;

    public override string ToString() => $"{Suit} {Rank}";
}
