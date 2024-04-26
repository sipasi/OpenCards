using OpenCards.Cards.SuitsRanks;
using OpenCards.Durak.Movements.Results;

namespace OpenCards.Durak.Movements;

public sealed class SimpleBotMove(IMovementValidator validator) : BotMovement(validator)
{
    public override IPlayerActionResult Defend(MovementArguments arguments)
    {
        var (player, deck, board) = (arguments.Current, arguments.Deck, arguments.Board);

        SuitRankCard trump = deck.Trump;
        SuitRankCard last = board.Attacks.Last();

        SuitRankCard? selected = player.Hand
            .MinRankWhere(card => card.EqualSuit(last) && card.Rank > last.Rank);

        if (selected is null && last.EqualSuit(trump) == false)
        {
            selected = player.Hand.MinRankBy(trump.Suit);
        }

        return selected is null
            ? new PlayerPassed()
            : new PlayerMoved(selected);
    }

    public override IPlayerActionResult FirstAttack(MovementArguments arguments)
    {
        var (player, deck) = (arguments.Current, arguments.Deck);

        SuitRankCard card =
            arguments.Current.Hand.MinRankWhere(card => card.Suit != deck.Trump.Suit) ??
            arguments.Current.Hand.MinRank()!;

        return new PlayerMoved(card);
    }

    public override IPlayerActionResult NextAttack(MovementArguments arguments)
    {
        var (player, board) = (arguments.Current, arguments.Board);

        SuitRankCard? selected = default;

        foreach (var card in player.Hand)
        {
            if (board.Any(card.EqualRank))
            {
                selected = card;
            }
        }

        return selected is null
            ? new PlayerPassed()
            : new PlayerMoved(selected);
    }

    public override IPlayerActionResult Toss(MovementArguments arguments) => NextAttack(arguments);
}