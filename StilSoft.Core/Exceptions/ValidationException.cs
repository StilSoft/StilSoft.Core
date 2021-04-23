using System;

namespace StilSoft.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(Exception innerException)
            : base("Validation error occurred, contact support.", innerException)
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}