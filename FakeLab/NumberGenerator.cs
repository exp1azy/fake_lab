namespace FakeLab
{
    internal class NumberGenerator
    {
        private readonly Random _random;

        internal NumberGenerator(Random random)
        {
            _random = random;
        }

        internal byte GenerateByte(byte min, byte max) =>
            (byte)_random.Next(min, max);

        internal short GenerateShort(short min, short max) =>
            (short)_random.Next(min, max);

        internal int GenerateInt(int min, int max) =>
            _random.Next(min, max);

        internal long GenerateLong(long min, long max) =>
            _random.NextInt64(min, max);

        internal double GenerateDouble(double min, double max) =>
            _random.NextDouble() * (max - min) + min;

        internal float GenerateFloat(float min, float max) => 
            (float)(_random.NextDouble() * (max - min) + min);

        internal decimal GenerateDecimal(decimal min, decimal max)
        {
            var range = max - min;
            double randomFactor = _random.NextDouble();

            return min + (range * (decimal)randomFactor);
        }
    }
}
