namespace ToDo.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}

public interface IPaginateQuery<TResponse> : IRequest<Pagination<TResponse>>
{
}