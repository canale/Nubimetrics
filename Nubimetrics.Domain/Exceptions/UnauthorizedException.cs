﻿using System;
using System.Runtime.Serialization;

namespace Nubimetrics.Domain.Exceptions
{
    public class UnauthorizedException : DomainException
    {
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
