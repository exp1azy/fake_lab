using Microsoft.Extensions.Configuration;
using System.Text;

namespace FakeLab
{
    internal class TextGenerator
    {
        private readonly Random _random;
        private readonly IConfiguration _config;

        private const string _path = @"Dataset/dataset.json";
        private readonly int[] _digits = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
        private readonly char[] _chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        
        internal TextGenerator(Random random)
        {
            _random = random;       

            _config = new ConfigurationBuilder()
                .AddJsonFile(_path, optional: false, reloadOnChange: true)
                .Build();
        }

        internal string GenerateName() => GetRandomStringFromDataset("names");
        internal string GenerateSurname() => GetRandomStringFromDataset("surnames");
        internal string GenerateAddress() => GetRandomStringFromDataset("addresses");

        internal string GenerateString(int length = 10, GenerateStringParams generateParams = GenerateStringParams.Randomly, bool includeDigits = true)
        {
            var stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                if (includeDigits)
                {
                    bool include = _random.Next(2) == 1;
                    if (include)
                    {
                        stringBuilder.Append(_digits[_random.Next(_digits.Length)]);
                        continue;
                    }                      
                }

                if (generateParams == GenerateStringParams.Uppercase)
                {
                    stringBuilder.Append(_chars[_random.Next(_chars.Length)].ToString().ToUpper());
                }                
                else if (generateParams == GenerateStringParams.Lowercase)
                {
                    stringBuilder.Append(_chars[_random.Next(_chars.Length)]);
                }                 
                else
                {
                    bool upper = _random.Next(2) == 1;
                    if (upper)
                        stringBuilder.Append(_chars[_random.Next(_chars.Length)].ToString().ToUpper());
                    else
                        stringBuilder.Append(_chars[_random.Next(_chars.Length)]);
                }              
            }

            return stringBuilder.ToString();
        }

        internal char GenerateChar()
        {
            var index = _random.Next(_chars.Length);

            return _chars[index];
        }

        private string GetRandomStringFromDataset(string section)
        {
            var strings = _config.GetSection(section).Get<string[]>();
            var index = _random.Next(strings.Length);

            return strings[index];
        }
    }
}
