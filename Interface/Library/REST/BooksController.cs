using System.Net.Mime;
using System.Runtime.Versioning;
using Domain.Library.Model.Aggregates;
using Domain.Library.Model.Commands;
using Domain.Library.Model.Queries;
using Domain.Library.Service;
using Interface.Library.REST.Resource;
using Interface.Library.REST.Transform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Interface.Library.REST;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[AllowAnonymous]
[ProducesResponseType(500)]
[ProducesResponseType(400)]
[Route("api/v1/[controller]")]
public class BooksController(IBookCommandService bookCommandService, IBookQueryService bookQueryService) : ControllerBase
{
    
    /// <summary>
    ///   Create a new book
    /// </summary>
    /// <response code="201">Returns the newly created book</response>
    /// <response code="400">If the book is null</response>
    /// <response code="500">If there is an internal server error</response>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookResource resource)
    {
        var createBookCommand = CreateBookCommandFromResourceAssembler.ToCommandFromResource(resource);
        var book  = await bookCommandService.Handle(createBookCommand);
        if (book == null) return BadRequest();
        var bookResource = BookResourceFromEntityAssembler.ToResourceFromEntityAssembler(book);
        return StatusCode(201, bookResource);

    }
    
    /// <summary>
    ///  Get all books 
    /// </summary>
    /// <response code="200">Returns the books</response>
    /// <response code="404">If the book is null</response>
    /// <response code="500">If there is an internal server error</response>
    
    [HttpGet]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAllBooks()
    { 
        var getAllBooks = new GetAllBooksQuery();
       var books = await bookQueryService.Handle(getAllBooks);
       if(books == null) return BadRequest();
       var resources = books.Select(BookResourceFromEntityAssembler.ToResourceFromEntityAssembler);
       return Ok(resources);
    }
    
    /// <summary>
    ///  Get a book by id
    /// </summary>
    /// <response code="200">Returns the book</response>
    /// <response code="404">If the book is null</response>
    /// <response code="500">If there is an internal server error</response>
    
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetBookById(long id)
    {
        var getBookByIdQuery = new GetBookByIdQuery(id);
        var book = await bookQueryService.Handle(getBookByIdQuery);
        if (book == null) return NotFound();
        var bookResource = BookResourceFromEntityAssembler.ToResourceFromEntityAssembler(book);
        return Ok(bookResource);
    }
    
}
