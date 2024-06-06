using Domain.Library.Model.Commands;

namespace Domain.Library.Model.Aggregates;

public partial class Book
{
    public long Id { get;  }
    
    public string Title { get;   set; }
    public string Description { get;    set; }
    public string Type { get;  set; }
}

public partial class Book
{
    public Book(long id, string title, string description, string type)
    {
        Id = id;
        Title = title;
        Description = description;
        Type = type;
    }
}

public partial class Book
{
    
    public Book(CreateBookCommand command)
    {
        Title = command.Title;
        Description = command.Description;
        Type = command.Type;
    }
    
}

