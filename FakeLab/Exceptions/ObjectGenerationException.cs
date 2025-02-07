namespace FakeLab.Exceptions
{
    internal class ObjectGenerationException : BaseGeneratorException
    {
        public ObjectGenerationException(string error, params string[] args) : base(error, args)
        {
        }
    }
}
