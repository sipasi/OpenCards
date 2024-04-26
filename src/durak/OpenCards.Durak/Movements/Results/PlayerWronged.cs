using OpenCards.Cards.SuitsRanks;

namespace OpenCards.Durak.Movements.Results;

public record PlayerWronged(SuitRankCard? Card = null) : IPlayerActionResult;
