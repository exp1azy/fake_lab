namespace FakeLab.Exceptions
{
    internal class InvalidRangeException(string error, params string[] values) : Exception(string.Format(error, values))
    {
    }
}
