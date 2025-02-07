namespace FakeLab.Exceptions
{
    internal class UnknownNumericValueException : BaseGeneratorException
    {
        public UnknownNumericValueException(string error, params string[] args) : base(error, args)
        {
        }
    }
}
