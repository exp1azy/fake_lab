namespace FakeLab.Exceptions
{
    internal class InvalidRangeException(string error, params string[] args) : BaseGeneratorException(error, args)
    {
    }
}
