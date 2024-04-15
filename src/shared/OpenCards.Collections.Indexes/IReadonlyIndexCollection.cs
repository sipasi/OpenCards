namespace OpenCards.Collections.Indexes;

public interface IReadonlyIndexCollection : IReadOnlyCollection<int>
{
    /// <summary>
    /// Gets the total capacity of the internal array (unchanging).
    /// </summary>
    public int Capacity { get; }

    public bool IsEmpty { get; }

    /// <summary>
    /// Peeks at an index based on an offset from the start
    /// </summary>
    /// <param name="offset">The offset from the start (0 for first index)</param>
    /// <returns>Index at the specified offset from the start</returns>
    int Peek(int offset = 0);

    /// <summary>
    /// Peeks at an index from the end
    /// </summary>
    /// <returns>Last index</returns>
    int PeekReverse();
}