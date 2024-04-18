namespace OpenCards.Cards.SuitsRanks;

public static class SuitRankCardExtension
{
    public static bool CanBeat(this SuitRankCard left, SuitRankCard right, SuitRankCard trump)
    {
        if (left.EqualSuit(right))
        {
            return left.Rank > right.Rank;
        }

        return left.EqualSuit(trump);
    }
    public static bool CanBeat(this SuitRankCard left, SuitRankCard right) => left.EqualSuit(right) && left.Rank > right.Rank;


    public static SuitRankCard? MinRankBy(this IEnumerable<SuitRankCard> cards, Suit suit) => cards.MinRankWhere(card => card.Suit == suit);

    public static SuitRankCard? MinRank(this IEnumerable<SuitRankCard> cards) => cards.MinBy(static card => card.Rank);

    public static SuitRankCard? MinRankWhere(this IEnumerable<SuitRankCard> cards, Func<SuitRankCard, bool> predicate)
        => cards.Where(predicate).MinBy(static card => card.Rank);

    public static bool AnyRank(this IEnumerable<SuitRankCard> cards, Rank rank) => cards.Any(item => item.Rank == rank);
}