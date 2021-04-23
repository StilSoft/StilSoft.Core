using System;
using StilSoft.Brokers.Loggings;
using StilSoft.Services.Exceptions;

namespace StilSoft.Services
{
    public abstract class ServiceBase
    {
        private readonly ILoggingBroker loggingBroker;

        protected ServiceBase(ILoggingBroker loggingBroker)
        {
            this.loggingBroker = loggingBroker;
        }

        protected ServiceException CreateAndLogServiceException(Exception exception)
        {
            var serviceException = new ServiceException(exception);

            this.loggingBroker.LogError(serviceException);

            return serviceException;
        }

        protected ServiceException CreateAndLogCriticalServiceException(Exception exception)
        {
            var serviceException = new ServiceException(exception);

            this.loggingBroker.LogCritical(serviceException);

            return serviceException;
        }

        protected ServiceDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var serviceDependencyException = new ServiceDependencyException(exception);

            this.loggingBroker.LogError(serviceDependencyException);

            return serviceDependencyException;
        }

        protected ServiceDependencyException CreateAndLogCriticalDependencyException(Exception exception)
        {
            var serviceDependencyException = new ServiceDependencyException(exception);

            this.loggingBroker.LogCritical(serviceDependencyException);

            return serviceDependencyException;
        }

        protected ServiceValidationException CreateAndLogValidationException(Exception exception)
        {
            var serviceValidationException = new ServiceValidationException(exception);

            this.loggingBroker.LogError(serviceValidationException);

            return serviceValidationException;
        }
    }
}