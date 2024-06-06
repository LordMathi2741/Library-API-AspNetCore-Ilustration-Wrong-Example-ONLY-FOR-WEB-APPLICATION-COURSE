using Domain.Library.Model.Aggregates;
using Domain.Shared.Repositories;

namespace Domain.Library.Repositories;

public interface IBookRepository : IBaseRepository<Book>
{

}