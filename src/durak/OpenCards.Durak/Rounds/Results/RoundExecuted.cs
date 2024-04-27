using OpenCards.Durak.Movements.Results;

namespace OpenCards.Durak.Rounds.Results;

public record class RoundExecuted(IPlayerActionResult Move) : IRoundResult;
