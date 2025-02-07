namespace FakeLab.Exceptions
{
    internal class BaseGeneratorException : Exception
    {
        public BaseGeneratorException(string error, params string[] args) : base(string.Format(error, args))
        {
        }
    }
}
