namespace FakeLab.Exceptions
{
    internal class CastException(string error, params string[] args) : BaseGeneratorException(error, args)
    {
    }
}
