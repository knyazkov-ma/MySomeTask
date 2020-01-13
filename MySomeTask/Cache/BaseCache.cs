using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace MySomeTask.Cache
{
  public abstract class BaseCache<T>
  {
    protected readonly IDistributedCache _cache;
    protected readonly string _cacheKeyPrefix;
    protected readonly int _duration = 100000;

    public BaseCache(IDistributedCache cache, string cacheKeyPrefix, int duration)
    {
      _cache = cache;
      _cacheKeyPrefix = cacheKeyPrefix;
      _duration = duration;
    }

    public void SetObject(string key, T item)
    {
      _cache.SetObject($"{_cacheKeyPrefix}:{key}", item, new TimeSpan(0, _duration, 0));
    }

    public async Task SetObjectAsync(string key, T item)
    {
      await _cache.SetObjectAsync($"{_cacheKeyPrefix}:{key}", item, new TimeSpan(0, _duration, 0));
    }

    public T AddOrGetExisting(string key, Func<T> valueFactory)
    {
      return _cache.AddOrGetExisting($"{_cacheKeyPrefix}:{key}", delegate ()
      {
        return valueFactory();
      }, new TimeSpan(0, _duration, 0));
    }

    public async Task<T> AddOrGetExistingAsync(string key, Func<T> valueFactory)
    {
      return await _cache.AddOrGetExistingAsync($"{_cacheKeyPrefix}:{key}", delegate ()
      {
        return valueFactory();
      }, new TimeSpan(0, _duration, 0));
    }

    public async Task<T> AddOrGetExistingAsync(string key, Func<Task<T>> valueFactory)
    {
      return await _cache.AddOrGetExistingAsync($"{_cacheKeyPrefix}:{key}", async delegate ()
      {
        return await valueFactory();
      }, new TimeSpan(0, _duration, 0));
    }

    public T GetObject(string key)
    {
      return _cache.GetObject<T>($"{_cacheKeyPrefix}:{key}");
    }

    public async Task<T> GetObjectAsync(string key)
    {
      return await _cache.GetObjectAsync<T>($"{_cacheKeyPrefix}:{key}");
    }

    public void Remove(string key)
    {
      _cache.Remove($"{_cacheKeyPrefix}:{key}");
    }

    public async Task RemoveAsync(string key)
    {
      await _cache.RemoveAsync($"{_cacheKeyPrefix}:{key}");
    }
  }
}
