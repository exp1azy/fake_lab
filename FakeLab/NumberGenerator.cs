namespace FakeLab
{
    internal class NumberGenerator
    {
        private readonly Random _random;

        internal NumberGenerator(Random random)
        {
            _random = random;
        }

        internal byte GenerateByte(byte min = byte.MinValue, byte max = byte.MaxValue) =>
            (byte)_random.Next(min, max);

        internal short GenerateShort(short min = short.MinValue, short max = short.MaxValue) =>
            (short)_random.Next(min, max);

        internal int GenerateInt(int min = int.MinValue, int max = int.MaxValue) =>
            _random.Next(min, max);

        internal long GenerateLong(long min = long.MinValue, long max = long.MaxValue) =>
            _random.NextInt64(min, max);

        internal double GenerateDouble(double min = double.MinValue, double max = double.MaxValue) =>
            _random.NextDouble() * (max - min) + min;

        internal float GenerateFloat(float min = float.MinValue, float max = float.MaxValue) => 
            (float)(_random.NextDouble() * (max - min) + min);

        internal decimal GenerateDecimal(decimal min = decimal.MinValue, decimal max = decimal.MaxValue) => 
            min + (decimal)(_random.NextDouble() * (double)(max - min));
    }
}
