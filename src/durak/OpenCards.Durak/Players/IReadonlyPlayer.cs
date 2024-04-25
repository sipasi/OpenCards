using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Hands;

namespace OpenCards.Durak.Players;

public interface IReadonlyPlayer
{
    int Id { get; }
    string Name { get; }
    MoveType MoveType { get; }

    IReadOnlyHand<SuitRankCard> Hand { get; }
}
