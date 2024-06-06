using Domain.Library.Model.Aggregates;
using Interface.Library.REST.Resource;

namespace Interface.Library.REST.Transform;

public static class BookResourceFromEntityAssembler
{
    public static BookResource ToResourceFromEntityAssembler(Book book)
    {
        return new BookResource(book.Id, book.Title, book.Description, book.Type);
    }
}