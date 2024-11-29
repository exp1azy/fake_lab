namespace FakeLab.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator();

            var user = generator.GenerateEntity<User>();
        }
    }
}
