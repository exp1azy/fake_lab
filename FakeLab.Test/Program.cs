namespace FakeLab.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator();

            var flag = generator.GenerateBoolean();
            var myChar = generator.GenerateCharacter();

            var myDateTime = generator.GenerateDateTime();
            var myDateOnly = generator.GenerateDateOnly();
            var myTimeSpan = generator.GenerateTimeSpan();
            var myTimeOnly = generator.GenerateTimeOnly();

            var dateTimeByInterval = generator.GenerateDateTimeByInterval(DateTime.MinValue, DateTime.Now);
            var dateOnlyByInterval = generator.GenerateDateOnlyByInterval(DateOnly.MinValue, DateOnly.MaxValue);
            var timeSpanByInterval = generator.GenerateTimeSpanByInterval(TimeSpan.Zero, TimeSpan.MaxValue);
            var timeOnlyByInterval = generator.GenerateTimeOnlyByInterval(TimeOnly.MinValue, TimeOnly.MaxValue);

            var user = generator.GenerateEntity<User>();
            var usersArray = generator.GenerateArray<User>();
            var usersMatrix = generator.GenerateMatrix<User>();
            var usersList = generator.GenerateList<User>(1000);
            var usersQueue = generator.GenerateQueue<User>(1000);
            var usersStack = generator.GenerateStack<User>(1000);
            var usersHashSet = generator.GenerateHashSet<User>(1000);
            var usersEnumerable = generator.GenerateEnumerableCollection<User>(1000);

            var myString = generator.GenerateString(20, GenerateStringParams.Randomly, false);
            var myName = generator.GenerateName();
            var mySurname = generator.GenerateSurname();
            var myAddress = generator.GenerateAddress();
            var myPhoneNumber = generator.GeneratePhoneNumber(7);
            var myEmail = generator.GenerateEmail();

            var myInt = generator.GenerateNumericValue(int.MinValue, int.MaxValue);
            var myInt64 = generator.GenerateNumericValue(long.MinValue, long.MaxValue);
            var myFloat = generator.GenerateNumericValue(1, float.MaxValue);
            var myDouble = generator.GenerateNumericValue(1, double.MaxValue);
            var myDecimal = generator.GenerateNumericValue(1, decimal.MaxValue);
            var myByte = generator.GenerateNumericValue(byte.MinValue, byte.MaxValue);
            var myInt16 = generator.GenerateNumericValue(short.MinValue, short.MaxValue);
        }
    }
}
