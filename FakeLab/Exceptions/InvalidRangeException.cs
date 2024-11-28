namespace FakeLab.Exceptions
{
    internal class InvalidRangeException : Exception
    {
        public InvalidRangeException() : base() { }
        public InvalidRangeException(string message) : base(message) { }
        public InvalidRangeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
