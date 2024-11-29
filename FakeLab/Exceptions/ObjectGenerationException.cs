namespace FakeLab.Exceptions
{
    public class ObjectGenerationException(string error, params string[] values) : Exception(string.Format(error, values))
    {
    }
}
