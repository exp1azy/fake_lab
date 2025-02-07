namespace FakeLab.Exceptions
{
    internal class InvalidPropertyAssignmentException : BaseGeneratorException
    {
        public InvalidPropertyAssignmentException(string error, params string[] args) : base(error, args)
        {
        }
    }
}
