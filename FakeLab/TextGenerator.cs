using FakeLab.Entities;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace FakeLab
{
    internal class TextGenerator : BaseGenerator
    {
        private readonly IConfigurationRoot _config;
        private const string _path = "Dataset\\text.json";
        private readonly int[] _digits = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
        private readonly char[] _chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray(); 

        internal TextGenerator()
        {
            Rand ??= new Random();

            _config = new ConfigurationBuilder()
               .AddJsonFile(_path)
               .Build();          
        }

        internal string GenerateRandom() => GenerateRandomString();
        internal string GenerateNickname() => (string)GenerateRequired("Nicknames");
        internal string GenerateName() => (string)GenerateRequired("Names");
        internal string GenerateSurname() => (string)GenerateRequired("Surnames");
        internal string GenerateFullName() => $"{GenerateName()} {GenerateSurname()}";
        internal string GenerateEmail() => (string)GenerateRequired("Emails");
        internal string GenerateAddress() => GenerateRequiredAddress(AddressType.Full);
        internal string GenerateStreet() => GenerateRequiredAddress(AddressType.Street);
        internal string GenerateCity() => GenerateRequiredAddress(AddressType.City);
        internal string GenerateCountry() => GenerateRequiredAddress(AddressType.Country);

        private string GenerateRandomString()
        {
            var length = 10;
            var stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                bool digit = GenerateBool();
                if (digit)
                {
                    stringBuilder.Append(_digits[Rand.Next(_digits.Length)]);
                }
                else
                {
                    bool upperCase = GenerateBool();

                    if (upperCase)
                        stringBuilder.Append(_chars[Rand.Next(_chars.Length)].ToString().ToUpper());
                    else
                        stringBuilder.Append(_chars[Rand.Next(_chars.Length)]);
                }
            }

            return stringBuilder.ToString();
        }

        private string GenerateRequiredAddress(AddressType type)
        {
            var address = (AddressEntity)GenerateRequired("Addresses");

            return type switch
            {
                AddressType.Full => $"{address.Country}, {address.City}, {address.Street}",
                AddressType.Country => address.Country,
                AddressType.City => address.City,
                AddressType.Street => address.Street,
                _ => throw new Exception()
            };
        }

        private object GenerateRequired(string field)
        {
            var names = _config[field];

            if (string.IsNullOrEmpty(names))
                throw new Exception();

            var required = JsonSerializer.Deserialize<object[]>(names) ?? throw new Exception();
            var index = Rand.Next(required.Length);

            return required[index];
        }
    }
}
