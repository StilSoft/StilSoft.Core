using System;

namespace StilSoft.Services.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(Exception innerException)
            : base("Service error occurred, contact support.", innerException)
        {
        }
    }
}