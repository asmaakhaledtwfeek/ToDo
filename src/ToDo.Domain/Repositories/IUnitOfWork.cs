using ToDo.Domain.Primitives;

namespace ToDo.Domain.Repositories;

public interface IUnitOfWork
{
    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : ValueObject;
}
