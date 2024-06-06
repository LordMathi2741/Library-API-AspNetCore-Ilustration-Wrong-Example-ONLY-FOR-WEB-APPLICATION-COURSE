using Domain.Library.Model.Aggregates;
using Domain.Library.Model.Commands;

namespace Domain.Library.Service;

public interface IBookCommandService
{
    Task<Book?> Handle (CreateBookCommand book);
}