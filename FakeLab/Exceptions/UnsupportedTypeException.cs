namespace FakeLab.Exceptions
{
    internal class UnsupportedTypeException : BaseGeneratorException
    {
        public UnsupportedTypeException(string error, params string[] args) : base(error, args)
        {
        }
    }
}
