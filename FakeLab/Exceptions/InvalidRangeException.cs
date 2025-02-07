namespace FakeLab.Exceptions
{
    internal class InvalidRangeException : BaseGeneratorException
    {
        public InvalidRangeException(string error, params string[] args) : base(error, args)
        {
        }
    }
}
