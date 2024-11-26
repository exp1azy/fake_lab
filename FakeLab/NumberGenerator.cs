namespace FakeLab
{
    internal class NumberGenerator : BaseGenerator
    {
        internal NumberGenerator()
        {
            Rand ??= new Random();
        }

        internal int GenerateInt(int min = int.MinValue, int max = int.MaxValue) =>
            Rand.Next(min, max);

        internal long GenerateLong(long min = long.MinValue, long max = long.MaxValue) =>
            Rand.NextInt64(min, max);

        internal double GenerateDouble(double min = double.MinValue, double max = double.MaxValue) => 
            Rand.NextDouble() * (max - min) + min;

        internal float GenerateFloat(float min = float.MinValue, float max = float.MaxValue) => 
            (float)(Rand.NextDouble() * (max - min) + min);

        internal decimal GenerateDecimal(decimal min = decimal.MinValue, decimal max = decimal.MaxValue) => 
            min + (decimal)(Rand.NextDouble() * (double)(max - min));

        internal int[] GenerateIntArray(int length = 10) => 
            new int[length].Select(x => GenerateInt()).ToArray();

        internal int[] GenerateIntArray(int min, int max, int length = 10) => 
            new int[length].Select(x => GenerateInt(min, max)).ToArray();

        internal long[] GenerateLongArray(int length = 10) =>
            new long[length].Select(x => GenerateLong()).ToArray();

        internal long[] GenerateLongArray(long min, long max, int length = 10) => 
            new long[length].Select(x => GenerateLong(min, max)).ToArray();

        internal double[] GenerateDoubleArray(int length = 10) => 
            new double[length].Select(x => GenerateDouble()).ToArray();

        internal double[] GenerateDoubleArray(double min, double max, int length = 10) => 
            new double[length].Select(x => GenerateDouble(min, max)).ToArray();

        internal float[] GenerateFloatArray(int length = 10) => 
            new float[length].Select(x => GenerateFloat()).ToArray();

        internal float[] GenerateFloatArray(float min, float max, int length = 10) => 
            new float[length].Select(x => GenerateFloat(min, max)).ToArray();

        internal decimal[] GenerateDecimalArray(int length = 10) => 
            new decimal[length].Select(x => GenerateDecimal()).ToArray();

        internal decimal[] GenerateDecimalArray(decimal min, decimal max, int length = 10) => 
            new decimal[length].Select(x => GenerateDecimal(min, max)).ToArray();
    }
}
