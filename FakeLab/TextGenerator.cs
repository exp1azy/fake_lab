using System.Text;

namespace FakeLab
{
    internal class TextGenerator
    {
        private readonly Random _random;

        private readonly int[] _digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly char[] _chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        
        internal TextGenerator(Random random)
        {
            _random = random;
        }

        internal string GenerateName() => GetRandomStringFromDataset("Names");
        internal string GenerateSurname() => GetRandomStringFromDataset("Surnames");
        internal string GenerateAddress() => GetRandomStringFromDataset("Addresses");

        internal string GenerateEmail()
        {
            var name = GetRandomStringFromDataset("Names").ToLower();
            var surname = GetRandomStringFromDataset("Surnames").ToLower();

            return $"{name}.{surname}@example.com";
        }

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

        private string GetRandomStringFromDataset(string key)
        {
            var strings = Dataset.Data.GetValueOrDefault(key);
            var index = _random.Next(strings.Length);

            return strings[index];
        }
    }
}
