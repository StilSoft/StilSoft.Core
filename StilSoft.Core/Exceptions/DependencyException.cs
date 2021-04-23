using System;

namespace StilSoft.Exceptions
{
    public class DependencyException : Exception
    {
        public DependencyException(Exception innerException)
            : base("Dependency error occurred, contact support.", innerException)
        {
        }

        public DependencyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DependencyException(string message)
            : base(message)
        {
        }
    }
}