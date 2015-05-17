using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace Reto.Helper
{
    public class CacheHelper
    {
        private static ObjectCache cache = MemoryCache.Default;

        public static void AddCache(string cacheKeyName, object cacheItem, CacheItemPriority cacheItemPriority)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.Priority = CacheItemPriority.Default;

            if (cacheItemPriority == CacheItemPriority.NotRemovable)
                policy.Priority = CacheItemPriority.NotRemovable;

            policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(0.5);
            cache.Set(cacheKeyName, cacheItem, policy);
        }

        public static object GetCache(string cacheKeyName)
        {
            return cache[cacheKeyName] as object;
        }

        public static void RemoveCache(string cacheKeyName)
        {
            if (cache.Contains(cacheKeyName))
                cache.Remove(cacheKeyName);
        }
    }
}
