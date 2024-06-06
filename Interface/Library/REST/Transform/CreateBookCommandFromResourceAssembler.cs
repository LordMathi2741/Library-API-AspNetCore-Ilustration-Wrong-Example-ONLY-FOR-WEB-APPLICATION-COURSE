using Domain.Library.Model.Commands;
using Interface.Library.REST.Resource;

namespace Interface.Library.REST.Transform;

public static class CreateBookCommandFromResourceAssembler
{
    public static CreateBookCommand ToCommandFromResource(CreateBookResource resource)
    {
        return new CreateBookCommand(resource.Title, resource.Description, resource.Type);
    }
    
}