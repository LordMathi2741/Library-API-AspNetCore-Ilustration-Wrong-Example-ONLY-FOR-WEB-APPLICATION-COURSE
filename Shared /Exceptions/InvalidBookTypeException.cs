namespace Infrastructure.Shared.Exceptions;

public class InvalidBookTypeException : Exception
{
    public InvalidBookTypeException(string message) : base(message)
    {
    }
    
    public InvalidBookTypeException(string message, Exception innerException) : base(message, innerException)
    {
    }
}