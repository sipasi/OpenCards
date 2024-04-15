using System.Text;

namespace OpenCards.Shared.Assertation;

public class AssertException : Exception
{
    private AssertException(string message) : base(message: message) { }

    public static void Throw<T>(T actual, T expected, string? info = null)
    {
        string message = string.Concat("Actual was ", actual, ", but expected ", expected, Environment.NewLine, info);

        throw new AssertException(message);
    }
}
