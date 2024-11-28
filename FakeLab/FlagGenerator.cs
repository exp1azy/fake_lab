namespace FakeLab
{
    internal class FlagGenerator
    {
        private readonly Random _random;

        internal FlagGenerator(Random random)
        {
            _random = random;
        }

        internal bool GenerateBool() => _random.Next(2) == 1;
    }
}
