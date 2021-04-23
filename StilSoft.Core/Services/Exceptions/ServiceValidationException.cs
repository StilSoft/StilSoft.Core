using System;

namespace StilSoft.Services.Exceptions
{
    public class ServiceValidationException : Exception
    {
        public ServiceValidationException(Exception innerException)
            : base("Service validation error occurred, contact support.", innerException)
        {
        }
    }
}