namespace FakeLab.Exceptions
{
    internal class UnknownNumericValueException(string error, params string[] args) : BaseGeneratorException(error, args)
    {
    }
}
