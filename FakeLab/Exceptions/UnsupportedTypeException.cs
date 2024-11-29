namespace FakeLab.Exceptions
{
    internal class UnsupportedTypeException(string error, params string[] args) : BaseGeneratorException(error, args)
    {
    }
}
