namespace Domain.Shared.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task <IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(long id);
}