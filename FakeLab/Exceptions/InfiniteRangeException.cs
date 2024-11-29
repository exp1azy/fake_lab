namespace FakeLab.Exceptions
{
    internal class InfiniteRangeException(string error, params string[] args) : BaseGeneratorException(error, args)
    {
    }
}
