namespace OpenCards.Cards.SuitsRanks;

public static class SuitRankBuilder
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

    /// <summary>
    /// Repeats the specified array of SuitRankCard objects a specified number of times.
    /// This method creates a new array with a length equal to the length of the input array multiplied by the 'times' parameter.
    /// It then copies the elements of the input array 'times' times into the new array, ensuring that the original order of elements is preserved.
    /// </summary>
    /// <param name="cards">The array of SuitRankCard objects to repeat.</param>
    /// <param name="times">The number of times to repeat the array.</param>
    /// <returns>
    /// A new array containing the elements of the input array repeated the specified number of times.
    /// </returns>
    /// <exception cref="System.ArgumentException">
    /// Thrown when the 'times' parameter is less than 1.
    /// </exception> 
    public static SuitRankCard[] Repeat(this SuitRankCard[] cards, int times)
    {
        if (times < 1)
        {
            throw new ArgumentException();
        }

        SuitRankCard[] result = new SuitRankCard[cards.Length * times];

        for (int i = 0; i < times; i++)
        {
            cards.CopyTo(result, i * cards.Length);
        }

        return result;
    }
}
