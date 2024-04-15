namespace OpenCards.Cards.SuitsRanks;

public class SuitRankBuilder
{
    /// <summary>
    /// Size is 52. Create from <see cref="Rank.Two"/> to <see cref="Rank.Ace"/> 
    /// </summary> 
    public static SuitRankCard[] Full() => Custom(from: Rank.Two, to: Rank.Ace);

    /// <summary>
    /// Size is 36. Create from <see cref="Rank.Six"/> to <see cref="Rank.Ace"/> 
    /// </summary> 
    public static SuitRankCard[] Medium() => Custom(from: Rank.Six, to: Rank.Ace);

    /// <summary>
    /// Size is 32. Create from <see cref="Rank.Seven"/> to <see cref="Rank.Ace"/> 
    /// </summary> 
    public static SuitRankCard[] Small() => Custom(from: Rank.Seven, to: Rank.Ace);

    /// <summary>
    /// Create custom cards list
    /// </summary>
    /// <param name="from">include</param>
    /// <param name="to">include</param>
    /// <returns></returns>
    public static SuitRankCard[] Custom(Rank from, Rank to)
    {
        const int zero_offset = 1;

        int ranks = to - from + zero_offset;
        int total = ranks * SuitHelper.count;

        List<SuitRankCard> cards = new(total);

        for (int suit = 0; suit < SuitHelper.count; suit++)
        {
            for (int rank = 0; rank < ranks; rank++)
            {
                cards.Add(new(
                    Suit: (Suit)suit,
                    Rank: from + rank)
               );
            }
        }

        return cards.ToArray();
    }
}
