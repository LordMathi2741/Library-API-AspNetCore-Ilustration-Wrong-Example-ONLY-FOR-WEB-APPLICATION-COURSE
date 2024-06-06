namespace Infrastructure.Shared.Exceptions;

public class DescriptionIsLongException : Exception
{
    public DescriptionIsLongException(string message) : base(message)
    {
    }
    
    public DescriptionIsLongException(string message, Exception innerException) : base(message, innerException)
    {
    }
}