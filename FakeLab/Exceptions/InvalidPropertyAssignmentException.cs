namespace FakeLab.Exceptions
{
    internal class InvalidPropertyAssignmentException(string error, params string[] args) : BaseGeneratorException(error, args)
    {
    }
}
