using System.Reflection;

namespace FakeLab
{
    public class DataGenerator : BaseGenerator
    {
        private readonly DateGenerator _dateGenerator = new();
        private readonly NumberGenerator _numberGenerator = new();
        private readonly TextGenerator _textGenerator = new();

        public TObject Generate<TObject>() where TObject : class, new() => (TObject)Generate(typeof(TObject));

        public new static bool GenerateBool() => GenerateBool();

        public DateTime GenerateDateTime() => _dateGenerator.GenerateDateTime();
        public DateTime GenerateDateTimeByInterval(DateTime from, DateTime to) => _dateGenerator.GenerateDateTimeByInterval(from, to);
        public DateTime GenerateDateTimeFrom(DateTime from) => _dateGenerator.GenerateDateTimeFrom(from);
        public DateTime GenerateDateTimeTo(DateTime to) => _dateGenerator.GenerateDateTimeTo(to);
        public DateOnly GenerateDateOnly() => _dateGenerator.GenerateDateOnly();
        public DateOnly GenerateDateOnlyByInterval(DateOnly from, DateOnly to) => _dateGenerator.GenerateDateOnlyByInterval(from, to);
        public DateOnly GenerateDateOnlyFrom(DateOnly from) => _dateGenerator.GenerateDateOnlyFrom(from);
        public DateOnly GenerateDateOnlyTo(DateOnly to) => _dateGenerator.GenerateDateOnlyTo(to);

        public int GenerateInt(int min = int.MinValue, int max = int.MaxValue) => _numberGenerator.GenerateInt(min, max);
        public float GenerateFloat(float min = float.MinValue, float max = float.MaxValue) => _numberGenerator.GenerateFloat(min, max);
        public double GenerateDouble(double min = double.MinValue, double max = double.MaxValue) => _numberGenerator.GenerateDouble(min, max);
        public decimal GenerateDecimal(decimal min = decimal.MinValue, decimal max = decimal.MaxValue) => _numberGenerator.GenerateDecimal(min, max);
        public int[] GenerateIntArray(int length = 10) => _numberGenerator.GenerateIntArray(length);
        public int[] GenerateIntArray(int min, int max, int length = 10) => _numberGenerator.GenerateIntArray(min, max, length);
        public float[] GenerateFloatArray(int length = 10) => _numberGenerator.GenerateFloatArray(length);
        public float[] GenereateFloatArray(float min, float max, int length = 10) => _numberGenerator.GenerateFloatArray(min, max, length);
        public double[] GenerateDoubleArray(int length = 10) => _numberGenerator.GenerateDoubleArray(length);
        public double[] GenerateDoubleArray(double min, double max, int length = 10) => _numberGenerator.GenerateDoubleArray(min, max, length);
        public decimal[] GenerateDecimalArray(int length = 10) => _numberGenerator.GenerateDecimalArray(length);
        public decimal[] GenerateDecimalArray(decimal min, decimal max, int length = 10) => _numberGenerator.GenerateDecimalArray(min, max, length);

        public string GenerateRandomString() => _textGenerator.GenerateRandom();
        public string GenerateNickname() => _textGenerator.GenerateNickname();
        public string GenerateName() => _textGenerator.GenerateName();
        public string GenerateSurname() => _textGenerator.GenerateSurname();
        public string GenerateFullName() => _textGenerator.GenerateFullName();
        public string GenerateEmail() => _textGenerator.GenerateEmail();
        public string GenerateAddress() => _textGenerator.GenerateAddress();
        public string GenerateStreet() => _textGenerator.GenerateStreet();
        public string GenerateCity() => _textGenerator.GenerateCity();
        public string GenerateCountry() => _textGenerator.GenerateCountry();

        private object Generate(Type type)
        {
            if (type == null)
                throw new Exception();

            if (type.IsPrimitive || type == typeof(string) || type.IsValueType)           
                return GeneratePrimitive(type);
            
            object instance = Activator.CreateInstance(type)!;
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!property.CanWrite)
                    continue;

                property.SetValue(instance, Generate(property.PropertyType));
            }

            return instance;
        }

        private object GeneratePrimitive(Type type)
        {
            if (type == typeof(int))
                return _numberGenerator.GenerateInt();
            if (type == typeof(float))
                return _numberGenerator.GenerateFloat();
            if (type == typeof(double))
                return _numberGenerator.GenerateDouble();
            if (type == typeof(decimal))
                return _numberGenerator.GenerateDecimal();
            if (type == typeof(bool))
                return GenerateBool();
            if (type == typeof(string))
                return _textGenerator.GenerateRandom();
            if (type == typeof(DateTime))
                return _dateGenerator.GenerateDateTime();
            if (type == typeof(Guid))
                return Guid.NewGuid();

            throw new Exception();
        }
    }
}
