

using Infrastructure.Shared.Exceptions;

namespace Domain.Library.Model.ValueObjects;

public record BookType(string Type)
{
    public BookType() : this(string.Empty)
    {
       
    }
    
    
}