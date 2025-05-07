using System.Linq.Expressions;
using ToDo.Domain.Primitives;
using ToDo.Domain.Repositories;
using ToDo.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ToDo.Persistence.Repositories
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : ValueObject
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<TEntity> _entity;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }
        public bool HasData()
             => _entity.Any();
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
            => await _entity.AddAsync(entity, cancellationToken);
        public async Task AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default)
            => await _entity.AddRangeAsync(entities, cancellationToken);
        public void Delete(TEntity entity)
            => _entity.Remove(entity);
        public void DeleteRange(IEnumerable<TEntity> entity)
            => _entity.RemoveRange(entity);
        public void Update(TEntity entity)
            => _entity.Update(entity);
        public void UpdateRange(IEnumerable<TEntity> entities)
            => _entity.UpdateRange(entities);
        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _entity.FindAsync(id, cancellationToken);
        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => await _entity.FindAsync(id, cancellationToken);
        public async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
            => await _entity.FindAsync(id, cancellationToken);
        public async Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
            => await _entity.FindAsync(id, cancellationToken);
        public (IQueryable<TEntity> data, int count) GetWithSpec(Specification<TEntity> specifications)
            => SpecificationEvaluator<TEntity>.GetQuery(_entity, specifications);
        public TEntity? GetEntityWithSpec(Specification<TEntity> specifications)
            => SpecificationEvaluator<TEntity>.GetQuery(_entity, specifications).data.FirstOrDefault();
        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
            => await _entity.AnyAsync(filter, cancellationToken);
        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken) > 0;
        public IReadOnlyList<TEntity> Get()
            => _entity.AsNoTracking().ToList();
        public void ExecuteUpdateRange(Expression<Func<TEntity, bool>> filter,
                Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> expression)
            => _entity.Where(filter).ExecuteUpdate(expression);
    }
}
