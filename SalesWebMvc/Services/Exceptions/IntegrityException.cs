using System;

namespace SalesWebMvc.Services.Exceptions
{
    public class IntegrityException : SystemException
    {
        public IntegrityException() : base()
        {
        }

        public IntegrityException(string message) : base(message)
        {
        }

        public IntegrityException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}