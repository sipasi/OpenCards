namespace OpenCards.Collections.Indexes;

public interface IIndexCollection : IReadonlyIndexCollection
{
    /// <summary>
    /// Returns and removes the next index from the collection.
    /// Decrements the size counter after returning the index.
    /// </summary>
    /// <returns>The next index.</returns>
    int Next();

    /// <summary>
    /// Fills the internal array with ascending numbers from 0 to Count-1.
    /// </summary>
    void Fill();

    /// <summary>
    /// Randomizes the order of indexes within a specified range (from, to) for the given number of times.
    /// </summary>
    /// <param name="times">The number of times to shuffle the indexes.</param>
    void Randomize(int times);

    /// <summary>
    /// Randomizes the order of indexes within a specified range (from, to) for the given number of times.
    /// </summary>
    /// <param name="from">The starting index for randomization (inclusive).</param>
    /// <param name="times">The number of times to shuffle the indexes.</param>
    void Randomize(int from, int times);

    /// <summary>
    /// Resets the size counter to the full capacity of the array, indicating all indexes are available again.
    /// </summary>
    void ResetIndex();
}