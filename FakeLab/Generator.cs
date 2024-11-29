using FakeLab.Exceptions;
using FakeLab.Resources;
using System.Numerics;
using System.Reflection;

namespace FakeLab
{
    public class Generator
    {
        private readonly GeneratorFactory _factory;
        private Type _currentType;

        public Generator()
        {
            _factory = new GeneratorFactory(new Random());
        }

        public TEntity GenerateEntity<TEntity>() where TEntity : class, new()
        {
            _currentType = typeof(TEntity);
            return (TEntity)GenerateRequiredObject(typeof(TEntity));
        }
            
        public TEnum GenerateEnum<TEnum>() where TEnum : Enum =>
            (TEnum)GenerateRequiredEnum(typeof(TEnum));

        public TObject[] GenerateArray<TObject>(int count = 10) =>
            (TObject[])GenerateRequiredCollection(typeof(TObject[]), count);

        public IEnumerable<TObject> GenerateEnumerable<TObject>(int count = 10) =>
            (IEnumerable<TObject>)GenerateRequiredCollection(typeof(IEnumerable<TObject>), count);
            
        public List<TObject> GenerateList<TObject>(int count = 10) =>
            (List<TObject>)GenerateRequiredCollection(typeof(List<TObject>), count);

        public Queue<TObject> GenerateQueue<TObject>(int count = 10) =>
            (Queue<TObject>)GenerateRequiredCollection(typeof(Queue<TObject>), count);

        public Stack<TObject> GenerateStack<TObject>(int count = 10) =>
            (Stack<TObject>)GenerateRequiredCollection(typeof(Stack<TObject>), count);

        public HashSet<TObject> GenerateHashSet<TObject>(int count = 10) =>
            (HashSet<TObject>)GenerateRequiredCollection(typeof(HashSet<TObject>), count);

        public LinkedList<TObject> GenerateLinkedList<TObject>(int count = 10) =>
            (LinkedList<TObject>)GenerateRequiredCollection(typeof(LinkedList<TObject>), count);

        public SortedSet<TObject> GenerateSortedSet<TObject>(int count = 10) =>
            (SortedSet<TObject>)GenerateRequiredCollection(typeof(SortedSet<TObject>), count);      

        public bool GenerateBool() => _factory.FlagGenerator.GenerateBool();    
        public char GenerateChar() => _factory.TextGenerator.GenerateChar();

        public DateTime GenerateDateTime() => _factory.DateGenerator.GenerateDateTime();
        public DateOnly GenerateDateOnly() => _factory.DateGenerator.GenerateDateOnly();
        public TimeOnly GenerateTimeOnly() => _factory.DateGenerator.GenerateTimeOnly();
        public TimeSpan GenerateTimeSpan() => _factory.DateGenerator.GenerateTimeSpan();

        public DateTime GenerateDateTimeByInterval(DateTime from, DateTime to) => 
            GenerateByInterval(from, to, _factory.DateGenerator.GenerateDateTimeByInterval);

        public DateOnly GenerateDateOnlyByInterval(DateOnly from, DateOnly to) =>
            GenerateByInterval(from, to, _factory.DateGenerator.GenerateDateOnlyByInterval);

        public TimeSpan GenerateTimeSpanByInterval(TimeSpan from, TimeSpan to) =>
            GenerateByInterval(from, to, _factory.DateGenerator.GenerateTimeSpanByInterval);

        public TimeOnly GenerateTimeOnlyByInterval(TimeOnly from, TimeOnly to) =>
            GenerateByInterval(from, to, _factory.DateGenerator.GenerateTimeOnlyByInterval);

        public string GenerateString(int length = 10, GenerateTextParams generateParams = GenerateTextParams.Randomly, bool includeDigits = true)
        {
            if (length <= 0)
                throw new ArgumentException(Error.LengthArgumentError);

            return _factory.TextGenerator.GenerateString(length, generateParams, includeDigits);
        }

        public TNumeric GenerateNumericValue<TNumeric>(TNumeric min, TNumeric max) where TNumeric : INumber<TNumeric>
        {
            var type = typeof(TNumeric);

            if (type == typeof(byte))
                return (TNumeric)(object)GenerateRequiredNumericValue((byte)(object)min, (byte)(object)max, _factory.NumberGenerator.GenerateByte);
            if (type == typeof(short))
                return (TNumeric)(object)GenerateRequiredNumericValue((short)(object)min, (short)(object)max, _factory.NumberGenerator.GenerateShort);
            if (type == typeof(int))
                return (TNumeric)(object)GenerateRequiredNumericValue((int)(object)min, (int)(object)max, _factory.NumberGenerator.GenerateInt);
            if (type == typeof(long))
                return (TNumeric)(object)GenerateRequiredNumericValue((long)(object)min, (long)(object)max, _factory.NumberGenerator.GenerateLong);
            if (type == typeof(float))
                return (TNumeric)(object)GenerateRequiredNumericValue((float)(object)min, (float)(object)max, _factory.NumberGenerator.GenerateFloat);
            if (type == typeof(double))
                return (TNumeric)(object)GenerateRequiredNumericValue((double)(object)min, (double)(object)max, _factory.NumberGenerator.GenerateDouble);
            if (type == typeof(decimal))
                return (TNumeric)(object)GenerateRequiredNumericValue((decimal)(object)min, (decimal)(object)max, _factory.NumberGenerator.GenerateDecimal);

            throw new UnknownNumericValueException(Error.UnknownNumericalValue, type.FullName!);
        }

        #region Private methods

        private TTimeValue GenerateByInterval<TTimeValue>(TTimeValue from, TTimeValue to, Func<TTimeValue, TTimeValue, TTimeValue> getTimeValue) 
            where TTimeValue : IComparable<TTimeValue>
        {
            if (from.CompareTo(to) > 0)
                throw new InvalidRangeException(Error.RangeError, from.ToString()!, to.ToString()!);

            return getTimeValue(from, to);
        }

        private TType GenerateRequiredNumericValue<TType>(TType min, TType max, Func<TType, TType, TType> getNumericValue) 
            where TType : INumber<TType>
        {
            if (min > max)
                throw new InvalidRangeException(Error.RangeError, min.ToString()!, max.ToString()!);

            return getNumericValue(min, max);
        }

        private Enum GenerateRequiredEnum(Type type)
        {
            Array values = Enum.GetValues(type);

            return (Enum)values.GetValue(_factory.NumberGenerator.GenerateInt(0, values.Length))!;
        }

        private object GenerateRequiredObject(Type type)
        {
            if (type.IsArray)
                return GenerateRequiredCollection(type);

            if (type.IsEnum)
                return GenerateRequiredEnum(type);

            if (type.IsGenericType)
            {
                var genericType = type.GetGenericTypeDefinition();

                if (genericType == typeof(List<>) ||
                    genericType == typeof(Queue<>) ||
                    genericType == typeof(Stack<>) ||
                    genericType == typeof(HashSet<>) ||
                    genericType == typeof(LinkedList<>) ||
                    genericType == typeof(SortedSet<>) ||
                    genericType == typeof(IEnumerable<>))
                {
                    return GenerateRequiredCollection(type);
                }
            }

            if (type.IsPrimitive || type == typeof(string) || type.IsValueType)
                return GeneratePrimitive(type);

            object instance = Activator.CreateInstance(type)!;
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!property.CanWrite)
                    continue;

                try
                {
                    ProcessSetValue(property, instance);
                }
                catch (UnsupportedTypeException) { throw; }
                catch (InvalidPropertyAssignmentException) { throw; }
                catch (ObjectGenerationException) { throw; }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }

            return instance;
        }

        private object GenerateRequiredCollection(Type collectionType, int count = 10)
        {
            if (collectionType.IsArray)
                return CreateObjectArray(collectionType, count);

            if (collectionType.IsInterface && collectionType.IsGenericType &&
                collectionType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                collectionType = typeof(List<>).MakeGenericType(collectionType.GetGenericArguments());
            }

            var genericArguments = collectionType.GetGenericArguments();

            if (genericArguments.Length != 1)
                throw new UnsupportedTypeException(Error.UnsupportedTypeError, collectionType.Name);
            
            Type itemType = genericArguments[0];
            if (itemType == _currentType)
                throw new ObjectGenerationException(Error.CyclicReferenceError, itemType.FullName!);

            var collection = Activator.CreateInstance(collectionType)!;

            var addMethod = (collectionType.GetMethod("Add") ??
                            collectionType.GetMethod("Enqueue") ??
                            collectionType.GetMethod("Push")) ??
                            throw new UnsupportedTypeException(Error.UnsupportedTypeError, collectionType.FullName!);

            for (int i = 0; i < count; i++)
            {
                var item = GenerateRequiredObject(itemType);
                addMethod.Invoke(collection, [item]);
            }

            return collection;
        }

        private void ProcessSetValue(PropertyInfo property, object instance)
        {
            if (property.PropertyType.IsArray)
            {
                Type elementType = property.PropertyType.GetElementType();
                var arrayValue = (Array)GenerateRequiredObject(property.PropertyType);
                Array targetArray = Array.CreateInstance(elementType, arrayValue.Length);

                for (int i = 0; i < arrayValue.Length; i++)                
                    targetArray.SetValue(arrayValue.GetValue(i), i);

                property.SetValue(instance, targetArray);
            }
            else
            {
                var value = GenerateRequiredObject(property.PropertyType);

                if (value != null && !property.PropertyType.IsAssignableFrom(value.GetType()))
                    throw new InvalidPropertyAssignmentException(Error.InvalidPropertyAssignment, value.GetType().Name, property.PropertyType.Name);

                property.SetValue(instance, value);
            }
        }

        private object[] CreateObjectArray(Type collectionType, int length)
        {
            var elem = collectionType.GetElementType();
            var array = new object[length];

            for (int i = 0; i < length; i++)
                array[i] = GenerateRequiredObject(elem!);

            return array;
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

            throw new UnsupportedTypeException(Error.UnsupportedTypeError, type.FullName!);
        }

        #endregion
    }
}
