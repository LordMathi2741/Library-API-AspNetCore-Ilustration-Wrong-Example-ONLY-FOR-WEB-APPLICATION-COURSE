namespace Domain.Library.Model.Exceptions;

public class InvalidBookTitleException : Exception
{
    public InvalidBookTitleException(string message) : base(message)
    {
    }
    
    public InvalidBookTitleException(string message, Exception innerException) : base(message, innerException)
    {
    }
}