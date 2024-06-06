using Domain.Library.Model.Aggregates;
using Domain.Library.Model.Queries;
using Domain.Library.Repositories;
using Domain.Library.Service;
using Domain.Shared.Repositories;

namespace Application.Library.Internal.BookQueryServices;

public class BookQueryService(IBookRepository repository, IUnitOfWork unitOfWork) : IBookQueryService
{
    public async Task<IEnumerable<Book>?> Handle(GetAllBooksQuery query)
    {
        return await repository.GetAllAsync();
    }

    public async Task<Book?> Handle(GetBookByIdQuery query)
    {
        return await repository.GetByIdAsync(query.Id);
    }
}