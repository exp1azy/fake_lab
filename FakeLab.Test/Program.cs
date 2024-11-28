namespace FakeLab.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator();

            var id = generator.GenerateInt(min: 0);
            var name = generator.GenerateString();
            var email = $"{generator.GenerateString(20, GenerateStringParams.Uppercase, false)}@mail.ru";
            var birth = generator.GenerateDateOnlyByInterval(new DateOnly(2000, 1, 1), new DateOnly(2024, 1, 1));

            int count = 1000;
            var usersList = generator.GenerateList<User>(count);
            var usersEnumerable = generator.GenerateEnumerable<User>(count);
            var usersArray = generator.GenerateArray<User>(count);

            var intList = generator.GenerateList<int>(count);
            var stringArray = generator.GenerateArray<string>(count);
            var dateEnumerable = generator.GenerateArray<DateTime>(count);
        }
    }
}
