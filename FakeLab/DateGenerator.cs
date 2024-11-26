namespace FakeLab
{
    internal class DateGenerator : BaseGenerator
    {
        internal DateGenerator()
        {
            Rand ??= new Random();
        }

        internal DateTime GenerateDateTime() => new(
            Rand.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year),
            Rand.Next(DateTime.MinValue.Month, DateTime.MaxValue.Month),
            Rand.Next(DateTime.MinValue.Day, DateTime.MaxValue.Day),
            Rand.Next(DateTime.MinValue.Hour, DateTime.MinValue.Hour),
            Rand.Next(DateTime.MinValue.Minute, DateTime.MinValue.Minute),
            Rand.Next(DateTime.MinValue.Second, DateTime.MinValue.Second)
        );

        internal DateTime GenerateDateTimeByInterval(DateTime from, DateTime to) => new(
            Rand.Next(from.Year, to.Year), 
            Rand.Next(from.Month, to.Month), 
            Rand.Next(from.Day, to.Day),
            Rand.Next(from.Hour, to.Hour),
            Rand.Next(from.Minute, to.Minute),
            Rand.Next(from.Second, to.Second)
        );

        internal DateTime GenerateDateTimeFrom(DateTime from) => new(
            Rand.Next(from.Year, DateTime.MaxValue.Year), 
            Rand.Next(from.Month, DateTime.MaxValue.Month), 
            Rand.Next(from.Day, DateTime.MaxValue.Day),
            Rand.Next(from.Hour, DateTime.MaxValue.Hour),
            Rand.Next(from.Minute, DateTime.MaxValue.Minute),
            Rand.Next(from.Second, DateTime.MaxValue.Second)
        );

        internal DateTime GenerateDateTimeTo(DateTime to) => new(
            Rand.Next(DateTime.MinValue.Year, to.Year), 
            Rand.Next(DateTime.MinValue.Month, to.Month), 
            Rand.Next(DateTime.MinValue.Day, to.Day),
            Rand.Next(DateTime.MinValue.Hour, to.Hour),
            Rand.Next(DateTime.MinValue.Minute, to.Minute),
            Rand.Next(DateTime.MinValue.Second, to.Second)
        );

        internal DateOnly GenerateDateOnly() => new(
            Rand.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year),
            Rand.Next(DateTime.MinValue.Month, DateTime.MaxValue.Month),
            Rand.Next(DateTime.MinValue.Day, DateTime.MaxValue.Day)
        );

        internal DateOnly GenerateDateOnlyByInterval(DateOnly from, DateOnly to) => new(
            Rand.Next(from.Year, to.Year),
            Rand.Next(from.Month, to.Month),
            Rand.Next(from.Day, to.Day)
        );

        internal DateOnly GenerateDateOnlyFrom(DateOnly from) => new(
            Rand.Next(from.Year, DateTime.MaxValue.Year),
            Rand.Next(from.Month, DateTime.MaxValue.Month),
            Rand.Next(from.Day, DateTime.MaxValue.Day)
        );

        internal DateOnly GenerateDateOnlyTo(DateOnly to) => new(
            Rand.Next(DateTime.MinValue.Year, to.Year),
            Rand.Next(DateTime.MinValue.Month, to.Month),
            Rand.Next(DateTime.MinValue.Day, to.Day)
        );
    }
}
