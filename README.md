# FakeLab

**FakeLab** is a powerful and versatile library for generating realistic fake data, designed to streamline the development, testing, and prototyping processes. Whether you're building unit tests, seeding databases, or demonstrating application features, FakeLab helps you save time by automating the creation of diverse, customizable datasets.

## Key Features

- **Comprehensive Type Support**: effortlessly generate data for primitive types, complex objects, arrays, collections and custom models.
- **Customizable Data Generation**: configure ranges, patterns, and constraints for numeric, string, and date values to match your requirements.
- **Built-in Support for Common Scenarios**: generate realistic names, addresses, emails, phone numbers, dates, and other frequently needed test data types.
- **Object Hierarchies**: automatically populate complex objects, including nested properties, based on their types and requirements.
- **Performance-Oriented**: designed to handle large-scale data generation with efficiency.
- **Developer-Friendly API**: clean, intuitive API that makes integration and usage straightforward, even for complex scenarios.

## Example Usage

```csharp
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
```

## Installation

Install FakeLab via NuGet Package Manager:
```bash
Install-Package FakeLab
```
Or use the .NET CLI:
```bash
dotnet add package FakeLab
```
## Why Choose FakeLab?
FakeLab is built with flexibility and efficiency in mind, making it suitable for a wide range of use cases:

- **Unit testing**: quickly generate consistent test datasets to validate your logic.
- **Database seeding**: populate development or test databases with meaningful data effortlessly.
- **Prototyping**: use realistic data in your application demos or UI prototypes.
- **Learning and experimentation**: simplify testing for beginners with ready-to-use data generation tools.

## License
FakeLab is distributed under the MIT License. See the [LICENSE](https://github.com/exp1azy/fake_lab/blob/main/FakeLab/LICENSE.txt) file for details.
