namespace FakeLab.Exceptions
{
    public class UnknownNumericValueException(string error, params string[] values) : Exception(string.Format(error, values))
    {
    }
}
