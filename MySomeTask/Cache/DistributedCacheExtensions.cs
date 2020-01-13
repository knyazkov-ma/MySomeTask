using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading.Tasks;

namespace MySomeTask.Cache
{
  public static class DistributedCacheExtensions
  {
    private static readonly TimeSpan _defaultOffset = new TimeSpan(1, 0, 0, 0);

    private static byte[] Serialize<T>(T item)
    {
      byte[] array = null;
      using (MemoryStream ms = new MemoryStream())
      {
        var formatter = new BinaryFormatter();
        formatter.Serialize(ms, item);
        array = ms.ToArray();
      }

      return array;
    }

    private static T Deserialize<T>(byte[] data)
    {
      using (MemoryStream ms = new MemoryStream(data))
      {
        var formatter = new BinaryFormatter();
        return (T)formatter.Deserialize(ms);
      }
    }

    public static void SetObject<T>(this IDistributedCache cache, string key, T item, TimeSpan? offset = null)
    {
      if (String.IsNullOrWhiteSpace(key) || item == null)
        return;

      var options = new DistributedCacheEntryOptions { SlidingExpiration = offset ?? _defaultOffset };
      cache.Set(key, Serialize(item), options);
    }


    public static async Task SetObjectAsync<T>(this IDistributedCache cache, string key, T item, TimeSpan? offset = null)
    {
      if (String.IsNullOrWhiteSpace(key) || item == null)
        return;

      var options = new DistributedCacheEntryOptions { SlidingExpiration = offset ?? _defaultOffset };
      await cache.SetAsync(key, Serialize(item), options);
    }

    public static T GetObject<T>(this IDistributedCache cache, string key)
    {
      if (String.IsNullOrWhiteSpace(key))
        throw new ArgumentException("Key should not be empty or null");

      var data = cache.Get(key);
      if (data == null)
        return default(T);

      return Deserialize<T>(data);
    }

    public static async Task<T> GetObjectAsync<T>(this IDistributedCache cache, string key)
    {
      if (String.IsNullOrWhiteSpace(key))
        throw new ArgumentException("Key should not be empty or null");

      var data = await cache.GetAsync(key);
      if (data == null)
        return default(T);

      return Deserialize<T>(data);
    }

    public static T AddOrGetExisting<T>(this IDistributedCache cache, string key, Func<T> valueFactory, TimeSpan? offset = null)
    {
      T item = GetObject<T>(cache, key);
      if (item == null)
      {
        item = valueFactory();
        SetObject(cache, key, item, offset);
      }

      return item;
    }

    public static async Task<T> AddOrGetExistingAsync<T>(this IDistributedCache cache, string key, Func<T> valueFactory, TimeSpan? offset = null)
    {
      T item = await GetObjectAsync<T>(cache, key);
      if (item == null)
      {
        item = valueFactory();
        await SetObjectAsync(cache, key, item, offset);
      }

      return item;
    }

    public static async Task<T> AddOrGetExistingAsync<T>(this IDistributedCache cache, string key, Func<Task<T>> valueFactory, TimeSpan? offset = null)
    {
      T item = await GetObjectAsync<T>(cache, key);
      if (item == null)
      {
        item = await valueFactory();
        await SetObjectAsync(cache, key, item, offset);
      }

      return item;
    }
  }
}
