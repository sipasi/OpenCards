namespace OpenCards.Shared.Assertation;

public static class Assert
{
    public static void IsFalse(bool condition, string? message = null)
    {
        if (condition is false)
        {
            return;
        }

        AssertException.Throw(actual: condition, expected: false, info: message);
    }
    public static void IsTrue(bool condition, string? message = null)
    {
        if (condition is true)
        {
            return;
        }

        AssertException.Throw(actual: condition, expected: true, info: message);
    }

    public static void AreEqual<T>(T? actual, T? expected, string? message = null)
    {
        bool equal = EqualityComparer<T>.Default.Equals(actual, expected);

        if (equal)
        {
            return;
        }

        AssertException.Throw(actual, expected, info: message);
    }

    public static void IsDefault<T>(T? actual, string? message = null)
    {
        bool equal = EqualityComparer<T>.Default.Equals(actual, default);

        if (equal)
        {
            return;
        }

        AssertException.Throw(actual, default, info: message);
    }

    public static void IsNotDefault<T>(T? actual, string? message = null)
    {
        bool equal = EqualityComparer<T>.Default.Equals(actual, default);

        if (equal == false)
        {
            return;
        }

        AssertException.Throw(actual?.ToString(), "not default", info: message);
    }
}
