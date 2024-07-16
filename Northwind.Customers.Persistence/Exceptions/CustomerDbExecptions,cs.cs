namespace Northwind.Customers.Persistence.Exceptions
{
    public class CustomerDbException : Exception
    {
        public CustomerDbException(string message) : base(message)
        {
        }

        public CustomerDbException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
