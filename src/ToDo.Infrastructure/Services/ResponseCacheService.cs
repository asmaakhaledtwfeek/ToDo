using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using ToDo.Application.Abstractions;

namespace ToDo.Infrastructure.Services;

internal class ResponseCacheService : IResponseCacheService
{
    private readonly IMemoryCache _memoryCache;

    public ResponseCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
    {
        if (response == null) return Task.CompletedTask;

        var options = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = timeToLive
        };

        _memoryCache.Set(cacheKey, response, options);

        return Task.CompletedTask;
    }

    public Task<string> GetCacheResponse(string cacheKey)
    {
        if (_memoryCache.TryGetValue(cacheKey, out object cachedResponse))
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            return Task.FromResult(JsonSerializer.Serialize(cachedResponse, options));
        }

        return Task.FromResult<string>(null!);
    }
}