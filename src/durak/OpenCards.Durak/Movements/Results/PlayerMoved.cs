using OpenCards.Cards.SuitsRanks;

namespace OpenCards.Durak.Movements.Results;

public record PlayerMoved(SuitRankCard Card) : IPlayerActionResult;
