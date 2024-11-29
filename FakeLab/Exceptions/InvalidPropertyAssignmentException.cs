namespace FakeLab.Exceptions
{
    public class InvalidPropertyAssignmentException(string error, params string[] values) : Exception(string.Format(error, values))
    {
    }
}
