using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;

namespace OpenCards.Durak.Collections.Boards;

public static class BoardExtension
{
    public static bool ContainsSuit(this IReadonlyBoard<SuitRankCard> board, SuitRankCard card) => board.Any(card.EqualSuit);
    public static bool ContainsRank(this IReadonlyBoard<SuitRankCard> board, SuitRankCard card) => board.Any(card.EqualRank);
    public static bool CollisionsRank(this IReadonlyBoard<SuitRankCard> board, IEnumerable<SuitRankCard> cards) => board.Any(item => cards.Any(item.EqualRank));
}
