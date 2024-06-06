using Domain.Shared.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;

namespace Infrastructure.Shared.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
         await context.SaveChangesAsync();
    }
}