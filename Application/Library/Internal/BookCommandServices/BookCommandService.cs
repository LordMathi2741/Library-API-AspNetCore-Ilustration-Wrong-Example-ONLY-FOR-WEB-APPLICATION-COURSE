using Domain.Library.Model.Aggregates;
using Domain.Library.Model.Commands;
using Domain.Library.Model.Exceptions;
using Domain.Library.Repositories;
using Domain.Library.Service;
using Domain.Shared.Repositories;
using Infrastructure.Shared.Exceptions;

namespace Application.Library.Internal.BookCommandServices;

public class BookCommandService(IBookRepository bookRepository, IUnitOfWork unitOfWork) : IBookCommandService
{
    public async Task<Book?> Handle(CreateBookCommand command)
    {
        var book = new Book(command);
        if (command.Type.ToLower() == "audiobook")
        {
            throw new InvalidBookTypeException("Audiobook is not allowed to be created.");
        }

        if (command.Title.Length < 10)
        {
            throw new InvalidBookTitleException("Book title must be at least 10 characters long.");
        }

        if (command.Description.Length > 100)
        {
            throw new DescriptionIsLongException("Description is long");
        }
        
        await bookRepository.AddAsync(book);
        await unitOfWork.CompleteAsync();
        return book;
    }
}