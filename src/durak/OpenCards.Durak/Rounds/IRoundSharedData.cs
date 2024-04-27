namespace OpenCards.Durak.Rounds;

public interface IRoundSharedData
{
    bool IsAttackerPassed { get; }
    bool IsDefenderPassed { get; }
    bool IsOver { get; }
}
