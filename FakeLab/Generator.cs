using FakeLab.Exceptions;
using FakeLab.Resources;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace FakeLab
{
    /// <summary>
    /// Provides functionality for generating random values of various types, including basic primitives and custom user-defined values.
    /// </summary>
    public class Generator
    {
        private readonly GeneratorFactory _factory;
        private Type _currentType;
        private bool _isCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="Generator"/> class.
        /// </summary>
        public Generator()
        {
            _factory = new GeneratorFactory(new Random());
        }

        /// <summary>
        /// Generates a random boolean value.
        /// </summary>
        public bool GenerateBoolean() => _factory.FlagGenerator.GenerateBoolean();

        /// <summary>
        /// Generates a random character.
        /// </summary>
        public char GenerateCharacter() => _factory.TextGenerator.GenerateChar();

        /// <summary>
        /// Generates a random name.
        /// </summary>
        /// <returns>A randomly generated name as a string.</returns>
        public string GenerateName() => _factory.TextGenerator.GenerateName();

        /// <summary>
        /// Generates a random surname.
        /// </summary>
        /// <returns>A randomly generated surname as a string.</returns>
        public string GenerateSurname() => _factory.TextGenerator.GenerateSurname();

        /// <summary>
        /// Generates a random address.
        /// </summary>
        /// <returns>A randomly generated address as a string.</returns>
        public string GenerateAddress() => _factory.TextGenerator.GenerateAddress();

        /// <summary>
        /// Generates a random <see cref="DateTime"/> value.
        /// </summary>
        public DateTime GenerateDateTime() => _factory.DateGenerator.GenerateDateTime();

        /// <summary>
        /// Generates a random <see cref="DateOnly"/> value.
        /// </summary>
        public DateOnly GenerateDateOnly() => _factory.DateGenerator.GenerateDateOnly();

        /// <summary>
        /// Generates a random <see cref="TimeOnly"/> value.
        /// </summary>
        public TimeOnly GenerateTimeOnly() => _factory.DateGenerator.GenerateTimeOnly();

        /// <summary>
        /// Generates a random <see cref="TimeSpan"/> value.
        /// </summary>
        public TimeSpan GenerateTimeSpan() => _factory.DateGenerator.GenerateTimeSpan();

        /// <summary>
        /// Generates a random <see cref="DateTime"/> value within the specified interval.
        /// </summary>
        public DateTime GenerateDateTimeByInterval(DateTime from, DateTime to) =>
            GenerateByInterval(from, to, _factory.DateGenerator.GenerateDateTimeByInterval);

        /// <summary>
        /// Generates a random <see cref="DateOnly"/> value within the specified interval.
        /// </summary>
        public DateOnly GenerateDateOnlyByInterval(DateOnly from, DateOnly to) =>
            GenerateByInterval(from, to, _factory.DateGenerator.GenerateDateOnlyByInterval);

        /// <summary>
        /// Generates a random <see cref="TimeSpan"/> value within the specified interval.
        /// </summary>
        public TimeSpan GenerateTimeSpanByInterval(TimeSpan from, TimeSpan to) =>
            GenerateByInterval(from, to, _factory.DateGenerator.GenerateTimeSpanByInterval);

        /// <summary>
        /// Generates a random <see cref="TimeOnly"/> value within the specified interval.
        /// </summary>
        public TimeOnly GenerateTimeOnlyByInterval(TimeOnly from, TimeOnly to) =>
            GenerateByInterval(from, to, _factory.DateGenerator.GenerateTimeOnlyByInterval);

        /// <summary>
        /// Generates a new instance of the specified entity type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to generate.</typeparam>
        /// <returns>A randomly generated instance of type <typeparamref name="TEntity"/>.</returns>
        public TEntity GenerateEntity<TEntity>() where TEntity : class, new()
        {
            _currentType = typeof(TEntity);
            _isCollection = false;
            return (TEntity)GenerateRequiredObject(typeof(TEntity));
        }

        /// <summary>
        /// Generates a random value of the specified enum type <typeparamref name="TEnum"/>.
        /// </summary>
        /// <typeparam name="TEnum">The enum type to generate a value for.</typeparam>
        /// <returns>A randomly generated value of type <typeparamref name="TEnum"/>.</returns>
        public TEnum GenerateEnum<TEnum>() where TEnum : Enum
        {
            _currentType = typeof(TEnum);
            _isCollection = false;
            return (TEnum)GenerateRequiredEnum(typeof(TEnum));
        }

        /// <summary>
        /// Generates an array of the specified type <typeparamref name="TObject"/> with a specified count of elements.
        /// Each element in the array is populated with a random value.
        /// </summary>
        /// <typeparam name="TObject">The type of the objects in the array.</typeparam>
        /// <param name="count">The number of elements to generate in the array. Defaults to 10.</param>
        /// <returns>An array of randomly generated <typeparamref name="TObject"/> values.</returns>
        public TObject[] GenerateArray<TObject>(int count = 10)
        {
            _currentType = typeof(TObject);
            _isCollection = false;
            var objectArray = (object[])GenerateRequiredCollection(typeof(TObject[]), count);

            return Array.ConvertAll(objectArray, (item) => (TObject)item);
        }

        /// <summary>
        /// Generates a 2-dimensional matrix of the specified type <typeparamref name="TObject"/> with a specified count of elements in each dimension.
        /// Each element in the matrix is populated with a random value.
        /// </summary>
        /// <typeparam name="TObject">The type of the objects in the matrix.</typeparam>
        /// <param name="count">The number of elements to generate in each dimension of the matrix. Defaults to 10.</param>
        /// <returns>A 2-dimensional array (matrix) of randomly generated <typeparamref name="TObject"/> values.</returns>
        public TObject[,] GenerateMatrix<TObject>(int count = 10)
        {
            _currentType = typeof(TObject);
            _isCollection = false;
            var objectMatrix = (object[,])GenerateRequiredCollection(typeof(TObject[,]), count);

            return ArrayConverter.ConvertToTypedMatrix<TObject>(objectMatrix);
        }

        /// <summary>
        /// Generates an enumerable collection of the specified type <typeparamref name="TObject"/> with a specified count of elements.
        /// Each element in the enumerable collection is populated with a random value.
        /// </summary>
        /// <typeparam name="TObject">The type of the objects in the enumerable collection.</typeparam>
        /// <param name="count">The number of elements to generate in the collection. Defaults to 10.</param>
        /// <returns>An enumerable collection of randomly generated <typeparamref name="TObject"/> values.</returns>
        public IEnumerable<TObject> GenerateEnumerableCollection<TObject>(int count = 10)
        {
            _currentType = typeof(TObject);
            _isCollection = true;

            return (IEnumerable<TObject>)GenerateRequiredCollection(typeof(IEnumerable<TObject>), count);
        }

        /// <summary>
        /// Generates a list of the specified type <typeparamref name="TObject"/> with a specified count of elements.
        /// Each element in the list is populated with a random value.
        /// </summary>
        /// <typeparam name="TObject">The type of the objects in the list.</typeparam>
        /// <param name="count">The number of elements to generate in the list. Defaults to 10.</param>
        /// <returns>A list of randomly generated <typeparamref name="TObject"/> values.</returns>
        public List<TObject> GenerateList<TObject>(int count = 10)
        {
            _currentType = typeof(TObject);
            _isCollection = true;

            return (List<TObject>)GenerateRequiredCollection(typeof(List<TObject>), count);
        }

        /// <summary>
        /// Generates a queue of the specified type <typeparamref name="TObject"/> with a specified count of elements.
        /// Each element in the queue is populated with a random value.
        /// </summary>
        /// <typeparam name="TObject">The type of the objects in the queue.</typeparam>
        /// <param name="count">The number of elements to generate in the queue. Defaults to 10.</param>
        /// <returns>A queue of randomly generated <typeparamref name="TObject"/> values.</returns>
        public Queue<TObject> GenerateQueue<TObject>(int count = 10)
        {
            _currentType = typeof(TObject);
            _isCollection = true;

            return (Queue<TObject>)GenerateRequiredCollection(typeof(Queue<TObject>), count);
        }

        /// <summary>
        /// Generates a stack of the specified type <typeparamref name="TObject"/> with a specified count of elements.
        /// Each element in the stack is populated with a random value.
        /// </summary>
        /// <typeparam name="TObject">The type of the objects in the stack.</typeparam>
        /// <param name="count">The number of elements to generate in the stack. Defaults to 10.</param>
        /// <returns>A stack of randomly generated <typeparamref name="TObject"/> values.</returns>
        public Stack<TObject> GenerateStack<TObject>(int count = 10)
        {
            _currentType = typeof(TObject);
            _isCollection = true;

            return (Stack<TObject>)GenerateRequiredCollection(typeof(Stack<TObject>), count);
        }

        /// <summary>
        /// Generates a hash set of the specified type <typeparamref name="TObject"/> with a specified count of elements.
        /// Each element in the hash set is populated with a random value.
        /// </summary>
        /// <typeparam name="TObject">The type of the objects in the hash set.</typeparam>
        /// <param name="count">The number of elements to generate in the hash set. Defaults to 10.</param>
        /// <returns>A hash set of randomly generated <typeparamref name="TObject"/> values.</returns>
        public HashSet<TObject> GenerateHashSet<TObject>(int count = 10)
        {
            _currentType = typeof(TObject);
            _isCollection = true;

            return (HashSet<TObject>)GenerateRequiredCollection(typeof(HashSet<TObject>), count);
        }

        /// <summary>
        /// Generates a random string of the specified length with optional parameters for text generation.
        /// </summary>
        /// <param name="length">The length of the generated string. Must be greater than 0. Defaults to 10.</param>
        /// <param name="generateParams">The parameters that define how the string should be generated, such as random or predefined patterns. Defaults to <see cref="GenerateStringParams.Randomly"/>.</param>
        /// <param name="includeDigits">Specifies whether digits should be included in the generated string. Defaults to true.</param>
        /// <returns>A randomly generated string based on the specified parameters.</returns>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="length"/> is less than or equal to 0.</exception>
        public string GenerateString(int length = 10, GenerateStringParams generateParams = GenerateStringParams.Randomly, bool includeDigits = true)
        {
            if (length <= 0)
                throw new ArgumentException(Error.LengthArgumentError);

            return _factory.TextGenerator.GenerateString(length, generateParams, includeDigits);
        }

        /// <summary>
        /// Generates a random phone number with the specified country code.
        /// </summary>
        /// <param name="code">The country code to be used for the phone number. Default is 1 (USA/Canada).</param>
        /// <returns>A randomly generated phone number as a string, formatted with the country code.</returns>
        public string GeneratePhoneNumber(int code = 1)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"+{code}");

            for (int i = 0; i < 10; i++)
            {
                var digit = _factory.NumberGenerator.GenerateInt(0, 9);
                stringBuilder.Append(digit);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Generates a random numeric value of the specified type <typeparamref name="TNumeric"/> within the given range.
        /// Supports byte, short, int, long, float, double, and decimal types.
        /// </summary>
        /// <typeparam name="TNumeric">The numeric type of the value to generate, must implement <see cref="INumber{T}"/>.</typeparam>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>A random numeric value of type <typeparamref name="TNumeric"/> within the specified range.</returns>
        /// <exception cref="InfiniteRangeException">Thrown if the range exceeds the numeric type's limits, specifically for float, double and decimal types.</exception>
        /// <exception cref="InvalidDecimalRangeException">Thrown if the range for decimal is invalid.</exception>
        /// <exception cref="UnknownNumericValueException">Thrown if an unsupported numeric type is provided.</exception>
        public TNumeric GenerateNumericValue<TNumeric>(TNumeric min, TNumeric max) where TNumeric : INumber<TNumeric>
        {
            var type = typeof(TNumeric);

            if (type == typeof(byte))
            {
                return (TNumeric)(object)GenerateRequiredNumericValue((byte)(object)min, (byte)(object)max, _factory.NumberGenerator.GenerateByte);
            }
            if (type == typeof(short))
            {
                return (TNumeric)(object)GenerateRequiredNumericValue((short)(object)min, (short)(object)max, _factory.NumberGenerator.GenerateShort);
            }
            if (type == typeof(int))
            {
                return (TNumeric)(object)GenerateRequiredNumericValue((int)(object)min, (int)(object)max, _factory.NumberGenerator.GenerateInt);
            }
            if (type == typeof(long))
            {
                return (TNumeric)(object)GenerateRequiredNumericValue((long)(object)min, (long)(object)max, _factory.NumberGenerator.GenerateLong);
            }
            if (type == typeof(float))
            {
                if ((float)(object)min < 0 && (float)(object)max > (float.MaxValue + (float)(object)min))
                    throw new InfiniteRangeException(Error.InfiniteError);

                return (TNumeric)(object)GenerateRequiredNumericValue((float)(object)min, (float)(object)max, _factory.NumberGenerator.GenerateFloat);
            }
            if (type == typeof(double))
            {
                if ((double)(object)min < 0 && (double)(object)max > (double.MaxValue + (double)(object)min))
                    throw new InfiniteRangeException(Error.InfiniteError);

                return (TNumeric)(object)GenerateRequiredNumericValue((double)(object)min, (double)(object)max, _factory.NumberGenerator.GenerateDouble);
            }  
            if (type == typeof(decimal))
            {
                if ((decimal)(object)min < 0 && (decimal)(object)max > (decimal.MaxValue + (decimal)(object)min))
                    throw new InvalidDecimalRangeException(Error.InvalidDecimalRangeError, nameof(min), nameof(max));

                return (TNumeric)(object)GenerateRequiredNumericValue((decimal)(object)min, (decimal)(object)max, _factory.NumberGenerator.GenerateDecimal);
            }

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
            _currentType = type;

            if (type.IsArray)
                return GenerateRequiredCollection(type);

            if (type.IsGenericType)
            {
                var genericType = type.GetGenericTypeDefinition();

                if (genericType == typeof(List<>) ||
                    genericType == typeof(Queue<>) ||
                    genericType == typeof(Stack<>) ||
                    genericType == typeof(HashSet<>) ||
                    genericType == typeof(IEnumerable<>))
                {
                    _isCollection = true;
                    return GenerateRequiredCollection(type);
                }
            }

            _isCollection = false;

            if (type.IsEnum)
                return GenerateRequiredEnum(type);

            if (type.IsPrimitive || type == typeof(string) || type.IsValueType)
                return GeneratePrimitive(type);

            object instance = Activator.CreateInstance(type)!;
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!property.CanWrite)
                    continue;

                try
                {
                    ProcessSetValueToProperty(property, instance);
                }
                catch (UnsupportedTypeException) { throw; }
                catch (InvalidPropertyAssignmentException) { throw; }
                catch (ObjectGenerationException) { throw; }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }

            return instance;
        }

        private void ProcessSetValueToProperty(PropertyInfo property, object instance)
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

        private object GenerateRequiredCollection(Type collectionType, int count = 10)
        {
            if (collectionType.IsArray)
            {
                var dimensions = collectionType.GetArrayRank();

                return dimensions switch
                {
                    1 => ArrayConverter.CreateObjectArray(collectionType, count, GenerateRequiredObject),
                    2 => ArrayConverter.CreateObjectMatrix(collectionType, count, count, GenerateRequiredObject),
                    _ => throw new UnsupportedTypeException(Error.UnsupportedTypeError, collectionType.Name)
                };
            } 

            if (collectionType.IsInterface && collectionType.IsGenericType &&
                collectionType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                collectionType = typeof(List<>).MakeGenericType(collectionType.GetGenericArguments());
            }

            var genericArguments = collectionType.GetGenericArguments();

            if (genericArguments.Length != 1)
                throw new UnsupportedTypeException(Error.UnsupportedTypeError, collectionType.Name);
            
            Type itemType = genericArguments[0];
            if (!_isCollection && itemType == _currentType)
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

        private object GeneratePrimitive(Type type)
        {
            if (type == typeof(byte))
                return _factory.NumberGenerator.GenerateByte(0, byte.MaxValue);
            if (type == typeof(short))
                return _factory.NumberGenerator.GenerateShort(0, short.MaxValue);
            if (type == typeof(int))
                return _factory.NumberGenerator.GenerateInt(0, int.MaxValue);
            if (type == typeof(long))
                return _factory.NumberGenerator.GenerateLong(0, long.MaxValue);
            if (type == typeof(float))
                return _factory.NumberGenerator.GenerateFloat(0, float.MaxValue);
            if (type == typeof(double))
                return _factory.NumberGenerator.GenerateDouble(0, double.MaxValue);
            if (type == typeof(decimal))
                return _factory.NumberGenerator.GenerateDecimal(0, decimal.MaxValue - 1);
            if (type == typeof(bool))
                return _factory.FlagGenerator.GenerateBoolean();
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
