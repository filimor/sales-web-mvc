using System;

namespace SalesWebMvc.Services.Exceptions
{
    public class DbConcurrencyException : SystemException
    {
        public DbConcurrencyException()
        {
        }

        public DbConcurrencyException(string message) : base(message)
        {
        }

        public DbConcurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}