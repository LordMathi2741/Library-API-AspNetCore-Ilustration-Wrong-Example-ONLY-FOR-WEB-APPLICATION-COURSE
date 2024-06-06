
using Infrastructure.Shared.Exceptions;

namespace Domain.Library.Model.ValueObjects;

public record BookDescription(string Description)
{
    public  BookDescription() : this(string.Empty)
    {
        
    }
    

}