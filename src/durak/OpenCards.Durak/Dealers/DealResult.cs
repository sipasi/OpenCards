using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Extensions;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Dealers;

public readonly struct DealResult(IReadOnlyList<DealResult.Info> infos)
{
    public readonly IReadOnlyList<Info> infos = infos;

    public bool IsEmpty => infos.IsEmpty();

    public readonly struct Info(IReadonlyPlayer player, IEnumerable<SuitRankCard> cards)
    {
        public readonly IReadonlyPlayer player = player;
        public readonly IEnumerable<SuitRankCard> cards = cards;
    }
}
