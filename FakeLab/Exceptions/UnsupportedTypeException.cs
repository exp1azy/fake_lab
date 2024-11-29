namespace FakeLab.Exceptions
{
    public class UnsupportedTypeException(string error, params string[] values) : Exception(string.Format(error, values))
    {
    }
}
