using FakeLab.Exceptions;
using System.Collections.ObjectModel;
using System.Reflection;

namespace FakeLab
{
    public class Generator
    {
        private readonly GeneratorFactory _factory;

        public Generator()
        {
            _factory = new GeneratorFactory(new Random());
        }

        public TEntity GenerateEntity<TEntity>() where TEntity : class, new() => 
            (TEntity)GenerateRequiredObject(typeof(TEntity));

        public TEnum GenerateEnum<TEnum>() where TEnum : Enum =>
            GenerateRequiredEnum<TEnum>();

        public IEnumerable<TObject> GenerateEnumerable<TObject>(int count = 10) =>
            GenerateCollection<TObject>(count);
            
        public List<TObject> GenerateList<TObject>(int count = 10) =>
            [.. GenerateCollection<TObject>(count)];

        public TObject[] GenerateArray<TObject>(int count = 10) =>
            GenerateRequiredArray<TObject>(count);

        public bool GenerateBool() => _factory.FlagGenerator.GenerateBool();    
        public char GenerateChar() => _factory.TextGenerator.GenerateChar();
        public DateTime GenerateDateTime() => _factory.DateGenerator.GenerateDateTime();
        public DateOnly GenerateDateOnly() => _factory.DateGenerator.GenerateDateOnly();
        public TimeOnly GenerateTimeOnly() => _factory.DateGenerator.GenerateTimeOnly();
        public TimeSpan GenerateTimeSpan() => _factory.DateGenerator.GenerateTimeSpan();

        public string GenerateString(int length = 10, GenerateStringParams generateParams = GenerateStringParams.Randomly, bool includeDigits = true)
        {
            if (length <= 0)
                throw new ArgumentException();

            return _factory.TextGenerator.GenerateString(length, generateParams, includeDigits);
        }

        public DateTime GenerateDateTimeByInterval(DateTime from, DateTime to)
        {
            if (from > to)
                throw new InvalidRangeException();

            return _factory.DateGenerator.GenerateDateTimeByInterval(from, to);
        }
        
        public DateOnly GenerateDateOnlyByInterval(DateOnly from, DateOnly to)
        {
            if (from > to)
                throw new InvalidRangeException();

            return _factory.DateGenerator.GenerateDateOnlyByInterval(from, to);
        }
        
        public TimeOnly GenerateTimeOnlyByInterval(TimeOnly from, TimeOnly to)
        {
            if (from > to)
                throw new InvalidRangeException();

            return _factory.DateGenerator.GenerateTimeOnlyByInterval(from, to);
        }
        
        public TimeSpan GenerateTimeSpanByInterval(TimeSpan from, TimeSpan to)
        {
            if (from > to)
                throw new InvalidRangeException();

            return _factory.DateGenerator.GenerateTimeSpanByInterval(from, to);
        }

        public byte GenerateByte(byte min = byte.MinValue, byte max = byte.MaxValue)
        {
            if (min > max)
                throw new InvalidRangeException();

            return _factory.NumberGenerator.GenerateByte(min, max);
        }

        public short GenerateShort(short min = short.MinValue, short max = short.MaxValue)
        {
            if (min > max)
                throw new InvalidRangeException();

            return _factory.NumberGenerator.GenerateShort(min, max);
        }

        public int GenerateInt(int min = int.MinValue, int max = int.MaxValue)
        {
            if (min > max)
                throw new InvalidRangeException();

            return _factory.NumberGenerator.GenerateInt(min, max);
        }

        public long GenerateLong(long min = long.MinValue, long max = long.MaxValue)
        {
            if (min > max)
                throw new InvalidRangeException();

            return _factory.NumberGenerator.GenerateLong(min, max);
        }

        public float GenerateFloat(float min = float.MinValue, float max = float.MaxValue)
        {
            if (min > max)
                throw new InvalidRangeException();

            return _factory.NumberGenerator.GenerateFloat(min, max);
        }

        public double GenerateDouble(double min = double.MinValue, double max = double.MaxValue)
        {
            if (min > max)
                throw new InvalidRangeException();

            return _factory.NumberGenerator.GenerateDouble(min, max);
        }

        public decimal GenerateDecimal(decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
        {
            if (min > max)
                throw new InvalidRangeException();

            return _factory.NumberGenerator.GenerateDecimal(min, max);
        }

        private TObject[] GenerateRequiredArray<TObject>(int count = 10)
        {
            var array = new TObject[count];

            for (int i = 0; i < count; i++)            
                array[i] = (TObject)GenerateRequiredObject(typeof(TObject));
            
            return array;
        }

        private Collection<TObject> GenerateCollection<TObject>(int count = 10)
        {
            var collection = new Collection<TObject>();

            for (int i = 0; i < count; i++)            
                collection.Add((TObject)GenerateRequiredObject(typeof(TObject)));
            
            return collection;
        }

        private TEnum GenerateRequiredEnum<TEnum>()
        {
            Array values = Enum.GetValues(typeof(TEnum));

            return (TEnum)values.GetValue(_factory.NumberGenerator.GenerateInt(values.Length))!;
        }

        private object GenerateRequiredObject(Type type)
        {
            if (type.IsPrimitive || type == typeof(string) || type.IsValueType)
                return GeneratePrimitive(type);

            object instance = Activator.CreateInstance(type)!;
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!property.CanWrite)
                    continue;
                
                try
                {
                    object value = GenerateRequiredObject(property.PropertyType);

                    if (value != null && !property.PropertyType.IsAssignableFrom(value.GetType()))
                        throw new Exception($"Generated value type '{value.GetType().Name}' is not assignable to property type '{property.PropertyType.Name}'.");

                    property.SetValue(instance, value);
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }

            return instance;
        }

        private object GeneratePrimitive(Type type)
        {
            if (type == typeof(byte))
                return _factory.NumberGenerator.GenerateByte(min: 0);
            if (type == typeof(short))
                return _factory.NumberGenerator.GenerateShort(min: 0);
            if (type == typeof(int))
                return _factory.NumberGenerator.GenerateInt(min: 0);
            if (type == typeof(long))
                return _factory.NumberGenerator.GenerateLong(min: 0);
            if (type == typeof(float))
                return _factory.NumberGenerator.GenerateFloat(min: 0);
            if (type == typeof(double))
                return _factory.NumberGenerator.GenerateDouble(min: 0);
            if (type == typeof(decimal))
                return _factory.NumberGenerator.GenerateDecimal(min: 0);
            if (type == typeof(bool))
                return _factory.FlagGenerator.GenerateBool();
            if (type == typeof(char))
                return _factory.TextGenerator.GenerateChar();
            if (type == typeof(string))
                return _factory.TextGenerator.GenerateString();
            if (type == typeof(DateTime))
                return _factory.DateGenerator.GenerateDateTimeByInterval(new DateTime(1900, 1, 1), DateTime.UtcNow.Date);
            if (type == typeof(DateOnly))
                return _factory.DateGenerator.GenerateDateOnlyByInterval(new DateOnly(1900, 1, 1), DateOnly.FromDateTime(DateTime.UtcNow.Date));
            if (type == typeof(TimeOnly))
                return _factory.DateGenerator.GenerateTimeOnly();
            if (type == typeof(TimeSpan))
                return _factory.DateGenerator.GenerateTimeSpan();
            if (type == typeof(Guid))
                return Guid.NewGuid();

            throw new UnsupportedTypeException();
        }
    }
}
