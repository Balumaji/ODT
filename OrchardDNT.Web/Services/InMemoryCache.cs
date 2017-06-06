using OrchardDNT.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace OrchardDNT.Web.Services
{
    public class InMemoryCache : ICacheService
    {
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(10));
            }
            return item;
        }

        public bool AddToCollection<T>(string cacheKey, T item) where T : class
        {
            if (item == null)
            {
                IEnumerable<T> existing = MemoryCache.Default.Get(cacheKey) as IEnumerable<T>;
                existing.ToList().Add(item);
                MemoryCache.Default.Add(cacheKey, existing, DateTime.Now.AddMinutes(10));
                return true;
            }
            return false;
        }
    }
}