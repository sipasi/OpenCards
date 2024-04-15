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
}