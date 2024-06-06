namespace Domain.Shared.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}