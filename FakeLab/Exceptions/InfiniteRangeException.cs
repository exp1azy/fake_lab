namespace FakeLab.Exceptions
{
    internal class InfiniteRangeException : BaseGeneratorException
    {
        public InfiniteRangeException(string error, params string[] args) : base(error, args)
        {
        }
    }
}
