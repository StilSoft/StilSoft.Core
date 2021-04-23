using System;

namespace StilSoft.Services.Exceptions
{
    public class ServiceDependencyException : Exception
    {
        public ServiceDependencyException(Exception innerException)
            : base("Service dependency error occurred, contact support.", innerException)
        {
        }
    }
}