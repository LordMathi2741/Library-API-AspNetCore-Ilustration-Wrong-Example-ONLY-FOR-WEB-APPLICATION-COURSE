using Domain.Library.Model.Aggregates;
using Domain.Library.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.Library.Persistence.EFC.Repositories;

public class BookRepository(AppDbContext context) : BaseRepository<Book>(context), IBookRepository;