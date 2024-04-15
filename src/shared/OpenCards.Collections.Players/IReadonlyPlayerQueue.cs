namespace OpenCards.Collections.Players;

public interface IReadonlyPlayerQueue<out T>
{
    public T Attacker { get; }
    public T Defender { get; }
    public T Current { get; }

    public bool IsAttackerQueue { get; }
    public bool IsDefenderQueue { get; }
}