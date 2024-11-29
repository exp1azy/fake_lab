namespace FakeLab
{
    internal class FlagGenerator
    {
        private readonly Random _random;

        internal FlagGenerator(Random random)
        {
            _random = random;
        }

        internal bool GenerateBoolean() => _random.Next(2) == 1;
    }
}
