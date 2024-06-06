
using System.ComponentModel.DataAnnotations;

namespace Domain.Library.Model.Commands;

public  record CreateBookCommand([Required] string Title, [Required] string Description, [Required] string Type);