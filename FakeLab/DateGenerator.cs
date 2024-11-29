namespace FakeLab
{
    internal class DateGenerator
    {
        private readonly Random _random;

        internal DateGenerator(Random random)
        {
            _random = random;
        }

        internal DateTime GenerateDateTime()
        {
            int year = _random.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year + 1);
            int month = _random.Next(1, 13);
            int day = _random.Next(1, DateTime.DaysInMonth(year, month) + 1);

            int hour = _random.Next(0, 24);
            int minute = _random.Next(0, 60);
            int second = _random.Next(0, 60);

            return new DateTime(year, month, day, hour, minute, second);
        }

        internal DateTime GenerateDateTimeByInterval(DateTime from, DateTime to)
        {
            DateTime result;

            do
            {
                int year = _random.Next(from.Year, to.Year + 1);
                int month = _random.Next(1, 13);
                int day = _random.Next(1, DateTime.DaysInMonth(year, month) + 1);

                int hour = _random.Next(0, 24);
                int minute = _random.Next(0, 60);
                int second = _random.Next(0, 60);

                result = new DateTime(year, month, day, hour, minute, second);
            } 
            while (result < from || result > to);

            return result;
        }

        internal DateOnly GenerateDateOnly()
        {
            int year = _random.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year + 1);
            int month = _random.Next(1, 13);
            int day = _random.Next(1, DateTime.DaysInMonth(year, month) + 1);

            return new DateOnly(year, month, day);
        }

        internal DateOnly GenerateDateOnlyByInterval(DateOnly from, DateOnly to)
        {
            DateOnly result;

            do
            {
                int year = _random.Next(from.Year, to.Year + 1);
                int month = _random.Next(1, 13);
                int day = _random.Next(1, DateTime.DaysInMonth(year, month) + 1);

                result = new DateOnly(year, month, day);
            }
            while (result < from || result > to);

            return result;
        }

        internal TimeOnly GenerateTimeOnly()
        {
            int hour = _random.Next(0, 24);
            int minute = _random.Next(0, 60);
            int second = _random.Next(0, 60);
            int millisecond = _random.Next(0, 1000);

            return new TimeOnly(hour, minute, second, millisecond);
        }

        internal TimeOnly GenerateTimeOnlyByInterval(TimeOnly from, TimeOnly to)
        {
            TimeOnly result;

            do
            {
                int hour = _random.Next(from.Hour, to.Hour + 1);
                int minute = _random.Next(from.Minute, to.Minute + 1);
                int second = _random.Next(from.Second, to.Second + 1);
                int millisecond = _random.Next(from.Millisecond, to.Millisecond + 1);

                result = new TimeOnly(hour, minute, second, millisecond);
            }
            while (result < from || result > to);

            return result;
        }

        internal TimeSpan GenerateTimeSpan()
        {
            int days = _random.Next(0, 30);
            int hours = _random.Next(0, 24);
            int minutes = _random.Next(0, 60);
            int seconds = _random.Next(0, 60);
            int milliseconds = _random.Next(0, 1000);

            return new TimeSpan(days, hours, minutes, seconds, milliseconds);
        }

        internal TimeSpan GenerateTimeSpanByInterval(TimeSpan from, TimeSpan to)
        {
            long ticks = _random.NextInt64(from.Ticks, to.Ticks);
            return new TimeSpan(ticks);
        }
    }
}
