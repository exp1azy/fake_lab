namespace FakeLab.Exceptions
{
    internal class CastException : BaseGeneratorException
    {
        public CastException(string error, params string[] args) : base(error, args)
        {
        }
    }
}
