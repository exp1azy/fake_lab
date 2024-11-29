namespace FakeLab.Exceptions
{
    internal class ObjectGenerationException(string error, params string[] args) : BaseGeneratorException(error, args)
    {
    }
}
