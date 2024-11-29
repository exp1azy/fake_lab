namespace FakeLab.Exceptions
{
    internal class BaseGeneratorException(string error, params string[] args) : Exception(string.Format(error, args))
    {
    }
}
