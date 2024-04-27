namespace OpenCards.Durak.Rounds;

public record RoundSharedData : IRoundSharedData
{
    public bool IsAttackerPassed { get; private set; }
    public bool IsDefenderPassed { get; private set; }
    public bool IsOver { get; private set; }

    public void AttackerPass() => IsAttackerPassed = true;
    public void DefenderPass() => IsDefenderPassed = true;
    public void Over() => IsOver = true;
}
