using Domain.Library.Model.Aggregates;
using Domain.Library.Model.Queries;

namespace Domain.Library.Service;

public interface IBookQueryService
{
    Task<IEnumerable<Book>?> Handle(GetAllBooksQuery query);
    Task<Book?> Handle(GetBookByIdQuery query);
}