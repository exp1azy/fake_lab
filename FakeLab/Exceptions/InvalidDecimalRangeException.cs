namespace FakeLab.Exceptions
{
    internal class InvalidDecimalRangeException : BaseGeneratorException
    {
        public InvalidDecimalRangeException(string error, params string[] args) : base(error, args)
        {
        }
    }
}
