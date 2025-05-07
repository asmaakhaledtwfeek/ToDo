namespace ToDo.Application.Abstractions;

public interface IResponseCacheService
{
    Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);
    Task<string> GetCacheResponse(string cacheKey);
}
