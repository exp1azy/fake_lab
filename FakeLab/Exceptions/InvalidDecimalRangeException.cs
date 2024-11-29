namespace FakeLab.Exceptions
{
    internal class InvalidDecimalRangeException(string error, params string[] args) : BaseGeneratorException(error, args)
    {
    }
}
