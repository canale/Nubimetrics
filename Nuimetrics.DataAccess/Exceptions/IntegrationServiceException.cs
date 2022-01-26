using System;
using System.Runtime.Serialization;

namespace Nubimetrics.DataAccess.Exceptions
{
    public class IntegrationServiceException : InfrastructureException
    {
        public IntegrationServiceException()
        {
        }

        public IntegrationServiceException(string message) : base(message)
        {
        }

        public IntegrationServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IntegrationServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
