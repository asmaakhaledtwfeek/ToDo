using ToDo.Domain.Primitives;

namespace ToDo.Application.Extensions.FluentValidation;

public static class EntityExistValidator
{
    public static IRuleBuilderOptions<T, TKey> EntityExist<T, TEntity, TKey>(
    this IRuleBuilder<T, TKey> ruleBuilder,
    IGenericRepository<TEntity> entityRepo)
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
    {
        return ruleBuilder
            .MustAsync(async (id, cancellationToken)
                => await entityRepo.IsExistAsync(entity => entity.Id.Equals(id), cancellationToken)).WithMessage(Message.Application_NotFound);
    }
}
